using Godot;
using System;
using System.Collections.Generic;

namespace RPG;

[Tool]
public partial class DEditor : GraphEdit
{
    PackedScene _dnode = ResourceLoader.Load<PackedScene>("res://addons/dialogueeditor/DialougeNode.tscn");
    bool _isLinear;

    Vector2 MousePos;

    // Use for linear conversations or games
    // List<DialogueNode> Linear;

    Node2D pop;

    BinarySearchTree<DialogueNode> DialogueTree;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        if (DialogueTree == null)
        {
            DialogueTree = new BinarySearchTree<DialogueNode>();
        }

        pop = GetNode<Node2D>("DialogueContextMenu");
    }

    public override void _Process(double delta)
    {
        if (Visible)
        {
            MousePos = GetViewport().GetMousePosition();
            base._Process(delta);
        }
    }

    public void AddNode()
    {
        var Dialogue = (DNode)_dnode.Instantiate();
        DialogueTree.Insert(Dialogue.DialogueNode);
        AddChild(Dialogue);
    }
}
