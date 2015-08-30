using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.Patterns.ExtendableMDI.Attributes
{
    /// <summary>
    /// ActionAttribute provides the generic type constraint for the Extendable MDI action 
    /// attributes. 
    /// </summary>
    /// <remarks>
    /// Every action attribute should inherit from ActionAttribute class. The action handling methods 
    /// should have the action attribute being applied on. In this case, the main form of a MDI application 
    /// may have the ability of calling the action handling methods on each MDI child form it contains. This 
    /// makes the MDI application much extensible.
    /// </remarks>
    /// <example>
    /// <para>This example shows the usage of ActionAttribute, <see cref="SunnyChen.Common.Patterns.ExtendableMDI.MainFormBase"/> and 
    /// <see cref="SunnyChen.Common.Patterns.ExtendableMDI.MDIChildBase&lt;T&gt;"/>.</para>
    /// <code>
    /// public class PrintActionAttribute : ActionAttribute
    /// {
    ///     // We do not need to add any code here because we just want to
    ///     // use this class for identifying the printing action handler.
    /// }
    /// 
    /// public partial class frmMain : MainFormBase
    /// {
    ///     public override void UpdateElements()
    ///     {
    ///         if ((MDIChildren.Length > 0) &amp;&amp; (ActiveMdiChild is MDIChildBase&lt;frmMain&gt;))
    ///         {
    ///             MDIChildBase&lt;frmMain&gt; child = (ActiveMdiChild as MDIChildBase&lt;frmMain&gt;);
    ///             this.buttonPrint.Enabled = child.CanPrint;
    ///         }
    ///     }
    ///     
    ///     private void buttonPrint_click (object sender, System.EventArgs e)
    ///     {
    ///         this.InvokeAction&lt;frmMain, PrintActionAttribute&gt;();
    ///     }
    /// }
    /// 
    /// public partial class frmChild : MDIChildBase&lt;frmMain&gt;
    /// {
    ///     [PrintAction]
    ///     private void DoPrint()
    ///     {
    ///         // Add the print action here.
    ///     }
    ///     
    ///     public frmChild()
    ///     {
    ///         CanPrint = True;
    ///     }
    /// }
    ///
    /// </code>
    /// </example>
    public abstract class ActionAttribute : Attribute
    {
        
    }
}
