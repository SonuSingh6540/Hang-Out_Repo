using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BusinessLogicLayer;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using Utility;

namespace UI.Controllers
{
    public class PaymentController : BaseController
    {
        public ActionResult Index()
        {
            var objENUser = new enUser { ID = (int)Session["User_ID"] };
            var objBLUser = new blUser(objENUser);
            try
            {
                objBLUser.Read();
            }
            catch (Exception ex)
            {
                return RedirectToAction("misc", "error");
            }

            return View(objENUser);
        }
        [HttpPost]
        public ActionResult Index(enUser enUser_)
        {
            var sponsorID = "empty";
            if (enUser_.Sponsor_ID != null)
                sponsorID = enUser_.Sponsor_ID;
            string firstName = enUser_.Name.ToString();
            string amount = enUser_.Amount.ToString();
            string productInfo = sponsorID;
            string email = enUser_.E_Mail.ToString();
            string phone = enUser_.Contact;

            RemotePost myremotepost = new RemotePost();
            string key = "1HkO1qEM";
            string salt = "GhMrk0D7B2";

            //posting all the parameters required for integration.
            myremotepost.Url = "https://secure.payu.in/_payment";
            myremotepost.Add("key", "1HkO1qEM");
            string txnid = Generatetxnid();
            myremotepost.Add("txnid", txnid);
            myremotepost.Add("amount", amount);
            myremotepost.Add("productinfo", productInfo);
            myremotepost.Add("firstname", firstName);
            myremotepost.Add("phone", phone);
            myremotepost.Add("email", email);
            myremotepost.Add("surl", "http://hang-out.in/payment/return");//Change the success url here depending upon the port number of your local system.
            myremotepost.Add("furl", "http://hang-out.in/payment/return");//Change the failure url here depending upon the port number of your local system.
            myremotepost.Add("service_provider", "payu_paisa");
            string hashString = key + "|" + txnid + "|" + amount + "|" + productInfo + "|" + firstName + "|" + email + "|||||||||||" + salt;
            string hash = Generatehash512(hashString);
            myremotepost.Add("hash", hash);
            myremotepost.Post();
            return View();
        }
        public string Generatehash512(string text)
        {

            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        public string Generatetxnid()
        {
            Random rnd = new Random();
            string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
            string txnid1 = strHash.ToString().Substring(0, 20);

            return txnid1;
        }

        [HttpPost]
        public ActionResult Return(FormCollection form)
        {
            try
            {
                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;
                string TexationID = string.Empty;
                string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";

                if (form["status"].ToString() == "success")
                {
                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    merc_hash_string = ConfigurationManager.AppSettings["SALT"] + "|" + form["status"].ToString();

                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string = merc_hash_string + (form[merc_hash_var] != null ? form[merc_hash_var] : "");

                    }
                    //Response.Write(merc_hash_string);
                    merc_hash = Generatehash512(merc_hash_string).ToLower();

                    if (merc_hash != form["hash"])
                    {
                        TexationID = Request.Form["txnid"];
                        var ReferenceCode = Request.Form["productInfo"];
                        var Name = Request.Form["firstName"];
                        var Amount = Request.Form["amount"];
                        var E_Mail = Request.Form["email"];

                        dbHandler(Name, TexationID, ReferenceCode, Amount,E_Mail);
                        ViewData["Message"] = "Transection Successfully Done";
                        //Response.Write("Hash value did not matched");
                    }
                    else
                    {
                        TexationID = Request.Form["txnid"];
                        var ReferenceCode = Request.Form["productInfo"];
                        var Name = Request.Form["firstName"];
                        var Amount = Request.Form["amount"];
                        var E_Mail = Request.Form["email"];

                        dbHandler(Name, TexationID, ReferenceCode, Amount, E_Mail);
                        ViewData["Message"] = "Transection Successfully Done";
                    }
                    return View();
                }

                else
                {
                    ViewData["Message"] = "Transection fail";
                    return View();
                }
            }

            catch (Exception ex)
            {
                ViewData["Message"] = "Transection fail";
                Response.Write("<span style='color:red'>" + ex.Message + "</span>");
            }
            return View();
        }

        public void dbHandler(string name, string transtnID, string sponsorID, string amount,string email)
        {
            var objENPayment = new enPayment();
            objENPayment.Name = name;
            objENPayment.Transection_ID = transtnID;
            objENPayment.Reference_Code = sponsorID;
            if (sponsorID == "empty")
                objENPayment.Reference_Code = null;
            objENPayment.Amount = Convert.ToSingle(amount);
            objENPayment.E_Mail = email;
            var objBLPayment = new blPayment(objENPayment);
            try
            {
                objBLPayment.Create();
            }
            catch (Exception ex)
            {
                Log.Error("HangOut.UI.PaymentController.dbHandler  Error while Create() Payment Exception:-" + ex.ToString());
            }

            if (sponsorID != "empty")
            {
                var objENUser = new enUser() { Reference_Code =  sponsorID };
                var objBLUser = new blUser(objENUser);
                try
                {
                    objBLUser.Read();
                }
                catch (Exception ex)
                {
                    Log.Error("Hangout.UI.PaymentController.dbHandler Error while Read() User  Exception:-" + ex.ToString());
                }

                if(objENUser.ID > 0)
                {
                    var objENReward = new enReward();
                    objENReward.Type = (int)RewardType.ADVERTISEMENT;
                    objENReward.User_ID = objENUser.ID;
                    objENReward.Point = (int)RewardPoints.ADVERTISEMENT;
                    var objBLReward = new blReward(objENReward);
                    try
                    {
                        objBLReward.Create();
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Hangout.UI.PaymentController.dbHandler Error while Create() Reward Exception:- " + ex.ToString());
                    }
                }
            }
        }
    }
}


public class RemotePost
{
    private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();
    public string Url = "";
    public string Method = "post";
    public string FormName = "form1";

    public void Add(string name, string value)
    {
        Inputs.Add(name, value);
    }

    public void Post()
    {
        System.Web.HttpContext.Current.Response.Clear();

        System.Web.HttpContext.Current.Response.Write("<html><head>");

        System.Web.HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
        System.Web.HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
        for (int i = 0; i < Inputs.Keys.Count; i++)
        {
            System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", Inputs.Keys[i], Inputs[Inputs.Keys[i]]));
        }
        System.Web.HttpContext.Current.Response.Write("</form>");
        System.Web.HttpContext.Current.Response.Write("</body></html>");

        System.Web.HttpContext.Current.Response.End();
    }
}
