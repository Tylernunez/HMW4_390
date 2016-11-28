using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    public Maze maze = new Maze("E://School/CMPS/CMPS 390/test/test/maze.dat");
    public Node[,] Nodes;
    public GameObject[,] mazeObjects;
    public GameObject wall;
    public GameObject enter;
    public GameObject exit;
    public GameObject path;
    public Material pathKnown;
    public Material pathExplored;
    public int time;


    // Use this for initialization
    void Start () {
        maze.findSpaces();
        maze.findAdjacency();
        maze.printMatrix();
        //Draw the Search Methods
        Nodes = maze.getMazeNodes();
        makeGameMaze();
        //BFS

        //DFS
    }
    void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        //breadthFirstSearch();
        //depthFirstSearch();
        //updateMaze();

    }
    public void breadthFirstSearch()
    {
        SceneManager.LoadScene("Maze");
        Node current;
        //for each u E V - {s}
        foreach(Node n in Nodes)
        {
            //u.d = infinite
            n.setDistance(int.MaxValue);
        }  
        //s.d = 0
                maze.getEnter().setDistance(0);
        //Q = empty set
        ListQueue queue = new ListQueue();
        //EnQueue(Q,s)
        queue.enqueue(maze.getEnter());
        //While Q != empty set
        while(!queue.isEmpty())
        { 
            //u = Dequeue(Q)
            current = (Node)queue.dequeue();
            Debug.Log("(" + current.getX() + "," + current.getY() + ")");
            current.setExplored(true);
            current.setKnown(false);
            if (current == maze.getExit().getPrevious())
            {
                Debug.Log("Breadth First Search Complete");
                break;
            }
            
            //foreach v E G.Adj[u]
            foreach (Node n in current.getPaths())
            {
                //if v.d == infinite
                if (n.getDistance() == int.MaxValue)
                {
                    //v.d = u.d + 1
                    n.setDistance(current.getDistance() + 1);
                    //EnQueue(Q,v)
                    n.setKnown(true);
                    queue.enqueue(n);
                }

            }

        }
        
    }
    public void depthFirstSearch()
    {
        Node current = new Node();
        SceneManager.LoadScene("Maze");
        //for each u E G.V
        foreach (Node n in Nodes)
        {
            //u.color = white
            n.setColor("WHITE");
        }
        //time = 0
        time = 0;
        //for each u E G.V
        ListQueue queue = new ListQueue();
        //EnQueue(Q,s)
        queue.enqueue(maze.getEnter());
        //While Q != empty set
        while (!queue.isEmpty())
        {
            current = (Node)queue.dequeue();
            Debug.Log("(" + current.getX() + "," + current.getY() + ")");
            current.setExplored(true);
            current.setKnown(false);
            if (current == maze.getExit().getPrevious())
            {
                Debug.Log("depth First Search Complete");
                break;
            }

            foreach (Node n in current.getPaths())
            {
                //if u.color == white
                if (n.getColor() == "WHITE")
                {
                    //DFS-VISIT(G,u)
                    Debug.Log("(" + n.getX() + "," + n.getY() + ")");
                    depthFirstSearchVisit(n);

                }

            }
            
        }
    }
    public void depthFirstSearchVisit(Node current)
    {
        //time = time + 1
        time++;
        //u.d = time
        current.setDistance(time);
        //u.color = GRAY
        current.setColor("GRAY");
        //foreach v E G.Adj[u]
        foreach(Node n in current.getPaths())
        {
            //if v.color ==white
            if(n.getColor() == "WHITE")
            {
                //DFS-Visit(v)
                depthFirstSearchVisit(n);
            }

        }
        //u.color = black
        current.setColor("BLACK");
        //time = time + 1
        time++;
        //u.f = time
        current.setFinishTime(time);
    }
    public void makeGameMaze()
    {
        mazeObjects = new GameObject[maze.getRow(), maze.getCol()];
        foreach (Node n in Nodes)
        {
            if (n is Wall)
            {
                mazeObjects[n.getX(), n.getY()] = wall;
            }
            if (n is Path)
            {
                mazeObjects[n.getX(), n.getY()] = path;
            }
            if (n is Entrance)
            {
                mazeObjects[n.getX(), n.getY()] = enter;
            }
            if (n is Exit)
            {
                mazeObjects[n.getX(), n.getY()] = exit;
            }
        }
        for (int i = 0; i < maze.getRow(); i++)
        {
            for (int j = 0; j < maze.getCol(); j++)
            {
                if (mazeObjects[i, j] == wall)
                {
                    Instantiate(wall, new Vector3(i,0,j), Quaternion.identity);
                }
                if (mazeObjects[i, j] == path)
                {
                    Instantiate(path, new Vector3(i,0,j), Quaternion.identity);
                }
                if (mazeObjects[i, j] == enter)
                {
                    Instantiate(enter, new Vector3(i,0,j), Quaternion.identity);
                }
                if (mazeObjects[i, j] == exit)
                {
                    Instantiate(exit, new Vector3(i,0,j), Quaternion.identity);

                }
            }
        }
    }
    public void updateMaze()
    {
        for (int i = 0; i < maze.getRow(); i++)
        {
            for (int j = 0; j < maze.getCol(); j++)
            {
                if (Nodes[i,j] is Path)
                {
                    if (Nodes[i, j].getExplored())
                    {
                        mazeObjects[i, j].GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    }
                    else if (Nodes[i, j].getKnown())
                    {
                        mazeObjects[i, j].GetComponent<Renderer>().material.SetColor("_Color",Color.cyan);
                    }
                }
            }
        }
    }
}
