using UnityEngine;
using System.Collections;

public class VectorGridForce : MonoBehaviour 
{
	public VectorGrid m_VectorGrid;
	public float m_ForceScale;
	public bool m_Directional;
	public Vector3 m_ForceDirection;
	public float m_Radius;
	public Color m_Color = Color.white;
	public bool m_HasColor;
	public GameObject vectorGrid_obj;

	void Start()
	{

		vectorGrid_obj = GameObject.Find("Vector Grid");
		m_VectorGrid = vectorGrid_obj.GetComponent<VectorGrid>();

		m_Radius = m_Radius * transform.localScale.x;
		m_ForceScale = m_ForceScale * transform.localScale.x;
	}

	// Update is called once per frame
	void Update () 
	{
		if(m_VectorGrid)
		{
			if(m_Directional)
			{
				m_VectorGrid.AddGridForce(this.transform.position, m_ForceDirection * m_ForceScale, m_Radius, m_Color, m_HasColor);
			}
			else
			{
				m_VectorGrid.AddGridForce(this.transform.position, m_ForceScale, m_Radius, m_Color, m_HasColor);
			}
		}
	}
	
}
