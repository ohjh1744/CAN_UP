using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public enum EBTType {Sequence, Selector, Parallel, BTAction, BTCondition }

// Node 정보
[System.Serializable]
public class NodeData
{

    public bool isRoot;

    public EBTType NodeType;

    public string NodeName;

    // Action 노드일 경우 필요
    public PlayerAction PlayerAction; 

    // Condition 노드일 경우 필요
    public PlayerCondition PlayerCondition; 
}

//간선 정보
[System.Serializable]
public class EdgeData
{
    public string ParentName;

    public string[] ChildNames;
}


public class PlayerController : MonoBehaviour
{
    // 루트 노드
    private BTNode _root;

    // 정점들
    [SerializeField] private EdgeData[] _edgeDatas;

    // 간선들
    [SerializeField] private NodeData[] _nodeDatas;

    //노드 저장하는 공간
    private Dictionary<string, BTNode> _nodes = new Dictionary<string, BTNode>();

    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
       _root.Evaluate();
    }

    //노드 생성 및 트리 연결
    private void Init()
    {
        for(int i = 0; i < _nodeDatas.Length; i++)
        {
            BTNode btNode = new BTSelector();

            bool isRoot = _nodeDatas[i].isRoot;

            EBTType btType = _nodeDatas[i].NodeType;

            string btString = _nodeDatas[i].NodeName;

            PlayerAction playerAction = _nodeDatas[i].PlayerAction;

            PlayerCondition playerCondition = _nodeDatas[i].PlayerCondition;

            // 노드 생성
            switch (btType)
            {
                case EBTType.Sequence:
                    btNode = new BTSequence();
                    _nodes.Add(btString, btNode);
                    break;
                case EBTType.Selector:
                    btNode = new BTSelector();
                    _nodes.Add(btString, btNode);
                    break;
                case EBTType.Parallel:
                    btNode = new BTParallel();
                    _nodes.Add(btString, btNode);
                    break;
                case EBTType.BTAction:
                    btNode = new BTAction(playerAction.DoAction);
                    _nodes.Add(btString, btNode);
                    break;
                case EBTType.BTCondition:
                    btNode = new BTCondition(playerCondition.DoCheck);
                    _nodes.Add(btString, btNode);
                    break;
            }

            if (isRoot == true)
            {
                _root = btNode;
            }

        }

        //트리 연결
        for (int j = 0; j < _edgeDatas.Length; j++)
        {
            if (_nodes.ContainsKey(_edgeDatas[j].ParentName) == false)
            {
                Debug.Log($"Cant Find {_edgeDatas[j].ParentName} Node");
            }
            else
            {
                BTNode ParentNode = _nodes[_edgeDatas[j].ParentName];

                for (int k = 0; k < _edgeDatas[j].ChildNames.Length; k++)
                {
                    if (_nodes.ContainsKey(_edgeDatas[j].ChildNames[k]) == false)
                    {
                        Debug.Log($"Cant Find {_nodes[_edgeDatas[j].ChildNames[k]]} Node");
                    }
                    else
                    {
                        BTNode CHildNode = _nodes[_edgeDatas[j].ChildNames[k]];
                        ParentNode.AddChild(CHildNode);
                        Debug.Log(ParentNode);
                        Debug.Log(CHildNode);

                    }
                }
            }
        }
    }













}
