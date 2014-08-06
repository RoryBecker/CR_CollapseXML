using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;
using SP = DevExpress.CodeRush.StructuralParser;

namespace CR_CollapseXML
{
    public partial class PlugIn1 : StandardPlugIn
    {
        // DXCore-generated code...
        #region InitializePlugIn
        public override void InitializePlugIn()
        {
            base.InitializePlugIn();
            registerCollapseXML();
        }
        #endregion
        #region FinalizePlugIn
        public override void FinalizePlugIn()
        {
            //
            // TODO: Add your finalization code here.
            //

            base.FinalizePlugIn();
        }
        #endregion

        public void registerCollapseXML()
        {
            DevExpress.CodeRush.Core.Action CollapseXML = new DevExpress.CodeRush.Core.Action(components);
            ((System.ComponentModel.ISupportInitialize)(CollapseXML)).BeginInit();
            CollapseXML.ActionName = "CollapseXML";
            CollapseXML.ButtonText = "Collapse XML"; // Used if button is placed on a menu.
            CollapseXML.RegisterInCR = true;
            CollapseXML.Execute += CollapseXML_Execute;
            ((System.ComponentModel.ISupportInitialize)(CollapseXML)).EndInit();
        }
        private void CollapseXML_Execute(ExecuteEventArgs ea)
        {
            var Doc = CodeRush.Documents.ActiveTextDocument;
            var elements = new ElementEnumerable(Doc.FileNode, LanguageElementType.HtmlElement, true);
            foreach (SP.HtmlElement html in elements.OfType<SP.HtmlElement>())
            {
                var attributes = html.Attributes.OfType<SP.HtmlAttribute>().ToList();
                if (attributes.Any(at => at.Name.ToLower() == "id" || at.Name.ToLower() == "name"))
                    html.CollapseInView(Doc.ActiveView);
            }
        }
    }
}