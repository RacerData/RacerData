using System;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;

namespace RacerData.Themes.UI.Providers
{
    class ThemeNameSerializer<T> : CodeDomSerializer
{
    public override object Serialize(IDesignerSerializationManager manager, object value)
    {
        ThemeNameExtenderProvider provider = value as ThemeNameExtenderProvider;

        CodeDomSerializer baseClassSerializer = manager.GetSerializer(typeof(ThemeNameExtenderProvider).BaseType, typeof(CodeDomSerializer)) as CodeDomSerializer;
        CodeStatementCollection statements = baseClassSerializer.Serialize(manager, value) as CodeStatementCollection;

        IDesignerHost host = (IDesignerHost)manager.GetService(typeof(IDesignerHost));
        ComponentCollection components = host.Container.Components;
        this.SerializeExtender(manager, provider, components, statements);

        return statements;
    }

    private void SerializeExtender(
        IDesignerSerializationManager manager,
        ThemeNameExtenderProvider provider,
        ComponentCollection components,
        CodeStatementCollection statements)
    {
        foreach (IComponent component in components)
        {
            Control control = component as Control;

            if (control != null && (control as Form == null))
            {
                CodeMethodInvokeExpression methodcall = new CodeMethodInvokeExpression(base.SerializeToExpression(manager, provider), "SetThemeName");

                methodcall.Parameters.Add(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), control.Name));

                string constants = provider.GetThemeName(control);

                if (!String.IsNullOrEmpty(constants))
                {
                    methodcall.Parameters.Add(new CodeSnippetExpression(constants));

                }
                else
                {
                    methodcall.Parameters.Add(new CodePrimitiveExpression(null));
                }

                statements.Add(methodcall);
            }
        }
    }

}
}
