using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Bugzzinga.Infraestructura.Html
{
    public static class DataBindedExtensions
    {
        #region Label

        public static MvcHtmlString DataBindedDisplayPropertyFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Dictionary<string, object> htmlAttributes)
        {
            var htmlAttributesDictionary = new Dictionary<string, object>
                {
                    { "data-bind", string.Concat("text: ", ExpressionHelper.GetExpressionText(expression)) }
                };

            htmlAttributesDictionary.MergeWith(htmlAttributes);

            var sb = new StringBuilder("&nbsp;<span ");

            foreach (var o in htmlAttributesDictionary)
            {
                sb.Append(string.Format(" {0}=\"{1}\"", o.Key, o.Value));
            }

            sb.Append("></span>");

            return new MvcHtmlString(sb.ToString());
        }

        #endregion

        #region TextBox

        public static MvcHtmlString DataBindedTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                            Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.DataBindedTextBoxFor(expression, null);
        }

        public static MvcHtmlString DataBindedTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 object htmlAttributes)
        {
            return htmlHelper.DataBindedTextBoxFor(expression, ObjectToPropertiesDictionary(htmlAttributes));
        }

        public static MvcHtmlString DataBindedTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 Dictionary<string, object> htmlAttributes)
        {
            var htmlAttributesDictionary = new Dictionary<string, object>
                {
                    { "data-bind", string.Concat("value: ", ExpressionHelper.GetExpressionText(expression)) }
                };

            htmlAttributesDictionary.MergeWith(htmlAttributes);

            return htmlHelper.TextBoxFor(expression, htmlAttributesDictionary);
        }

        public static MvcHtmlString DataBindedLabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 Dictionary<string, object> htmlAttributes)
        {
            var htmlAttributesDictionary = new Dictionary<string, object>
            {
                { "data-bind", string.Concat("value: ", ExpressionHelper.GetExpressionText(expression), ", enable: false") }
            };

            htmlAttributesDictionary.MergeWith(htmlAttributes);

            return htmlHelper.TextBoxFor(expression, htmlAttributesDictionary);
        }

        [Obsolete("usar la sobrecarga de object htmlAttributes que ya maneja atributos repetidos")]
        public static MvcHtmlString DataBindedTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 object htmlAttributes, string databind)
        {
            //TODO: refactor this as a method with resharper.

            IDictionary<string, object> htmlAttributesDictionary = new Dictionary<string, object>();

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(htmlAttributes);

            foreach (PropertyDescriptor property in properties)
            {
                htmlAttributesDictionary.Add(property.Name, property.GetValue(htmlAttributes));
            }

            // end TODO

            htmlAttributesDictionary.Add("data-bind",
                                         !string.IsNullOrEmpty(databind)
                                             ? string.Concat("value: ", ExpressionHelper.GetExpressionText(expression),
                                                             " ,", databind)
                                             : string.Concat("value: ", ExpressionHelper.GetExpressionText(expression)));

            return htmlHelper.TextBoxFor(expression, htmlAttributesDictionary);
        }

        #endregion

        #region TextArea

        public static MvcHtmlString DataBindedTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Dictionary<string, object> htmlAttributes)
        {
            var htmlAttributesDictionary = new Dictionary<string, object>
                {
                    { "data-bind", string.Concat("value: ", ExpressionHelper.GetExpressionText(expression)) }
                };

            htmlAttributesDictionary.MergeWith(htmlAttributes);

            return htmlHelper.TextAreaFor(expression, htmlAttributesDictionary);
        }

        #endregion

        #region Checkbox

        public static MvcHtmlString DataBindedCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper,
                                                                       Expression<Func<TModel, bool>> expression)
        {
            return htmlHelper.DataBindedCheckBoxFor(expression, null);
        }

        public static MvcHtmlString DataBindedCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper,
                                                                       Expression<Func<TModel, bool>> expression,
                                                                       object htmlAttributes)
        {
            return htmlHelper.DataBindedCheckBoxFor(expression, ObjectToPropertiesDictionary(htmlAttributes));
        }

        public static MvcHtmlString DataBindedCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper,
                                                                       Expression<Func<TModel, bool>> expression,
                                                                       IDictionary<string, object> htmlAttributes)
        {
            var htmlAttributesDictionary = new Dictionary<string, object>
                {
                    { "data-bind", string.Concat("checked: ", ExpressionHelper.GetExpressionText(expression)) }
                };

            htmlAttributesDictionary.MergeWith(htmlAttributes);

            return htmlHelper.CheckBoxFor(expression, htmlAttributesDictionary);
        }

        #endregion

        #region DropDown

        public static MvcHtmlString DataBindedSelectFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                         Expression<Func<TModel, TProperty>> expression,
                                                                         IEnumerable<SelectListItem> selectList,
                                                                         Dictionary<string, object> htmlAttributes)
        {
            var htmlAttributesDictionary = new Dictionary<string, object>
                {
                    { "data-bind", string.Concat("value: ", ExpressionHelper.GetExpressionText(expression)) }
                };

            htmlAttributesDictionary.MergeWith(htmlAttributes);

            return htmlHelper.DropDownListFor(expression, selectList, htmlAttributesDictionary);
        }

        #endregion

        /// <summary>
        /// Agrega entradas o actualiza si existian en el diccionario, una para cada propiedad del objeto luego de utilizar <see cref="ObjectToPropertiesDictionary"/>
        /// </summary>        
        public static void MergeWith(this IDictionary<string, object> dictionary, object htmlAttributes)
        {
            var htmlAttributesDictionary = ObjectToPropertiesDictionary(htmlAttributes);

            dictionary.MergeWith(htmlAttributesDictionary);
        }

        public static void MergeWith(this IDictionary<string, object> target, IDictionary<string, object> update)
        {
            if (update == null) return;

            foreach (var attribute in update)
            {
                if (!target.ContainsKey(attribute.Key))
                {
                    target.Add(attribute.Key, attribute.Value);
                }
                else
                {
                    target[attribute.Key] = string.Concat(target[attribute.Key], SeparatorFor(attribute.Key), attribute.Value);
                }
            }
        }

        private static Dictionary<string, object> ObjectToPropertiesDictionary(object htmlAttributes)
        {
            var htmlAttributesDictionary = new Dictionary<string, object>();

            if (htmlAttributes == null) return htmlAttributesDictionary;

            var properties = TypeDescriptor.GetProperties(htmlAttributes);

            foreach (PropertyDescriptor property in properties)
            {
                var html5Name = property.Name.Replace("_", "-");

                htmlAttributesDictionary.Add(html5Name, property.GetValue(htmlAttributes));
            }

            return htmlAttributesDictionary;
        }

        private static string SeparatorFor(string propertyName)
        {
            return propertyName.ToLower() == "data-bind" ? ", " : " ";
        }
    }
}