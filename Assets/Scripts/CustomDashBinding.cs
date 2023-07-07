using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.InputSystem.Editor;
#endif

#if UNITY_EDITOR
[InitializeOnLoad]
#endif

[DisplayStringFormat("{Binding}*{Direction}")]

public class ButtonWithVector2 : InputBindingComposite<Vector2>
{
    //initialiser for class
    static ButtonWithVector2()
    {
        InputSystem.RegisterBindingComposite<ButtonWithVector2>(); //registers binding to the api
    }

    //first button binding
    [InputControl(layout = "Button")] 
    public int button;

    //returns vector 2
    [InputControl(layout = "Button")] 
    public int up;
    
    [InputControl(layout = "Button")] 
    public int down;
    
    [InputControl(layout = "Button")] 
    public int left;
    
    [InputControl(layout = "Button")] 
    public int right;
    
    //redefining ReadValue
    public override Vector2 ReadValue(ref InputBindingCompositeContext context)
    {
        //is each button pressed?
        bool upPressed = context.ReadValueAsButton(up);
        bool downPressed = context.ReadValueAsButton(down);
        bool leftPressed = context.ReadValueAsButton(left);
        bool rightPressed = context.ReadValueAsButton(right);
        
        //return if button is pressed
        return DpadControl.MakeDpadVector(upPressed, downPressed, leftPressed, rightPressed).normalized;
    }
    
    //redefining magnitude
    public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
    {
        var value = ReadValue(ref context);
        return value.magnitude;
    }
}