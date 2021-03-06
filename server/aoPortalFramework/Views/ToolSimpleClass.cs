
using Contensive.BaseClasses;
using System;

namespace Contensive.Addons.PortalFramework {
    public class ToolSimpleClass {
        //
        //-------------------------------------------------
        //
        private static string cr { get; } = System.Environment.NewLine + "\t";
        //
        //-------------------------------------------------
        //
        private static string cr2 { get; } = cr + "\t";
        //
        //-------------------------------------------------
        //
        private string localHiddenList { get; set; } = "";
        //
        //-------------------------------------------------
        //
        private string localButtonList { get; set; } = "";
        //
        //-------------------------------------------------
        //
        private string localFormId { get; set; } = "";
        //
        //-------------------------------------------------
        //
        private string localFormActionQueryString { get; set; } = "";
        //
        //-------------------------------------------------
        //
        bool localIncludeForm { get; set; }
        //
        //-------------------------------------------------
        //
        public bool includeBodyPadding { get; set; } = true;
        //
        //-------------------------------------------------
        //
        public bool includeBodyColor { get; set; } = true;
        //
        //-------------------------------------------------
        //
        public bool isOuterContainer { get; set; } = false;
        //
        //-------------------------------------------------
        // 
        public string title { get; set; } = "";
        //
        //-------------------------------------------------
        // 
        public string successMessage { get; set; } = "";
        //
        //-------------------------------------------------
        // 
        public string infoMessage { get; set; } = "";
        //
        //-------------------------------------------------
        // 
        public string warningMessage { get; set; } = "";
        //
        //-------------------------------------------------
        // 
        public string failMessage { get; set; } = "";
        //
        //-------------------------------------------------
        // 
        public string description { get; set; } = "";
        // 
        //-------------------------------------------------
        //
        public string getHtml(CPBaseClass cp) {
            string userErrors = cp.Utils.EncodeText(cp.UserError.GetList());
            if (!string.IsNullOrWhiteSpace(userErrors)) {
                warningMessage += userErrors;
            }
            string result = "";
            result += (string.IsNullOrWhiteSpace(title) ? "" : cr + "<h2>" + title + "</h2>");
            result += (string.IsNullOrWhiteSpace(successMessage) ? "" : cr + "<div class=\"p-3 mb-2 bg-success text-white\">" + successMessage + "</div>");
            result += (string.IsNullOrWhiteSpace(infoMessage) ? "" : cr + "<div class=\"p-3 mb-2 bg-info text-white\">" + infoMessage + "</div>");
            result += (string.IsNullOrWhiteSpace(warningMessage) ? "" : cr + "<div class=\"p-3 mb-2 bg-warning text-white\">" + warningMessage + "</div>");
            result += (string.IsNullOrWhiteSpace(failMessage) ? "" : cr + "<div class=\"p-3 mb-2 bg-danger text-white\">" + failMessage + "</div>");
            result += (string.IsNullOrWhiteSpace(description) ? "" : cr + "<p>" + description + "</p>");
            result += (string.IsNullOrWhiteSpace(body) ? "" : cr + "<main>" + body + "</main>");
            result += (string.IsNullOrWhiteSpace(footer) ? "" : cr + "<footer>" + footer + "</footer>");
            //
            // -- add wrappers
            string wrapperClass = "";
            wrapperClass += (includeBodyPadding) ? " p-4" : " p-0";
            wrapperClass += (includeBodyColor) ? " bg-light" : " bg-white";
            result = cp.Html.div(result, "", wrapperClass, "");
            //
            // a-- dd form
            if (localIncludeForm) {
                if (localButtonList != "") {
                    localButtonList = ""
                        + cr + "<div class=\"border bg-white p-2\">"
                        + indent(localButtonList)
                        + cr + "</div>";
                }
                result = cr + cp.Html.Form(localButtonList + result + localButtonList + localHiddenList, "", "", "", localFormActionQueryString, "");
            }
            //
            // if outer container, add styles and javascript
            //
            if (isOuterContainer) {
                result = ""
                    + cr + "<div id=\"\">"
                    + indent(result)
                    + cr + "</div>";
            }
            return result;
        }
        //
        //-------------------------------------------------
        // 
        public void addFormHidden(string Name, string Value, string htmlId) {
            localHiddenList += cr + "<input type=\"hidden\" name=\"" + Name + "\" value=\"" + Value + "\">";
            localIncludeForm = true;
        }
        //
        //-------------------------------------------------
        /// <summary>
        /// Create html input type hidden
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void addFormHidden(string name, int value) => addFormHidden(name, value.ToString(), "");
        /// <summary>
        /// Create html input type hidden
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="htmlId"></param>
        public void addFormHidden(string name, int value, string htmlId) => addFormHidden(name, value.ToString(), htmlId);
        //
        //-------------------------------------------------
        /// <summary>
        /// Create html input type hidden
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void addFormHidden(string name, double value) => addFormHidden(name, value.ToString(), "");
        /// <summary>
        /// Create html input type hidden
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="htmlId"></param>
        public void addFormHidden(string name, double value, string htmlId) => addFormHidden(name, value.ToString(), htmlId);
        //
        //-------------------------------------------------
        /// <summary>
        /// Create html input type hidden
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void addFormHidden(string name, DateTime value) => addFormHidden(name, value.ToString(), "");
        /// <summary>
        /// Create html input type hidden
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="htmlId"></param>
        public void addFormHidden(string name, DateTime value, string htmlId) => addFormHidden(name, value.ToString(), htmlId);
        //
        //-------------------------------------------------
        /// <summary>
        /// Create html input type hidden
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void addFormHidden(string name, bool value) => addFormHidden(name, value.ToString(), "");
        /// <summary>
        /// Create html input type hidden
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="htmlId"></param>
        public void addFormHidden(string name, bool value, string htmlId) => addFormHidden(name, value.ToString(), htmlId);
        //
        //-------------------------------------------------
        // 
        public void addFormButton(string buttonValue) {
            addFormButton(buttonValue, "button", "", "btn btn-primary mr-1 btn-sm");
        }
        //
        //-------------------------------------------------
        // 
        public void addFormButton(string buttonValue, string buttonName) {
            addFormButton(buttonValue, buttonName, "", "btn btn-primary mr-1 btn-sm");
        }
        //
        //-------------------------------------------------
        // 
        public void addFormButton(string buttonValue, string buttonName, string buttonId) {
            addFormButton(buttonValue, buttonName, buttonId, "btn btn-primary mr-1 btn-sm");
        }
        //
        //-------------------------------------------------
        // 
        public void addFormButton(string buttonValue, string buttonName, string buttonId, string buttonClass) {
            localButtonList += cr + "<input type=\"submit\" name=\"" + buttonName + "\" value=\"" + buttonValue + "\" id=\"" + buttonId + "\" class=\"afwButton " + buttonClass + "\">";
            localIncludeForm = true;
        }
        //
        //-------------------------------------------------
        // 
        public string formActionQueryString {
            get {
                return localFormActionQueryString;
            }
            set {
                localFormActionQueryString = value;
                localIncludeForm = true;
            }
        }
        //
        //-------------------------------------------------
        // 
        public string formId {
            get {
                return localFormId;
            }
            set {
                localFormId = value;
                localIncludeForm = true;
            }
        }
        //
        //-------------------------------------------------
        // 
        public string body { get; set; } = "";
        //
        //-------------------------------------------------
        // 
        public string footer { get; set; } = "";
        //
        //-------------------------------------------------
        //
        private string indent(string src) {
            return src.Replace(cr, cr2);
        }
    }
}
