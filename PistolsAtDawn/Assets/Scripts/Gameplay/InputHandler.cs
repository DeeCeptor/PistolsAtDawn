using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour 
{
	private Ray2D m_Ray;
	private RaycastHit2D m_RayCastHit;
	private ResizableObject m_CurrentObject;
	private Vector3 m_LastMousePos;
	private float m_DeltaTime;
	private bool m_AnimateScale;
	private Vector3 m_StartScale;
	private float m_ScaleFactor;
	
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			m_LastMousePos = Input.mousePosition;
			//m_Ray = (Ray2D) Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D m_Ray =  Physics2D.Raycast(new Vector2( Camera.main.ScreenToWorldPoint(Input.mousePosition).x,  Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
			//m_Raya.collider 
			//if(Physics2D.Raycast(m_Ray.origin, m_Ray.direction, out m_RayCastHit, Mathf.Infinity))
			if (m_Ray.collider != null)
			{
				ResizableObject obj = m_Ray.collider.gameObject.GetComponent<ResizableObject>();
				if(obj)
				{
					m_CurrentObject = obj;
					m_StartScale = obj.transform.localScale;
					
				}
			}
		}
		
		if(Input.GetMouseButton(0))
		{
			Vector3 deltaPosition = Input.mousePosition - m_LastMousePos;
			if(deltaPosition.magnitude > 1f)
			{
				if(m_CurrentObject && !m_AnimateScale)
				{
					m_ScaleFactor = deltaPosition.magnitude;
					m_AnimateScale = true;
					m_DeltaTime = 0f;
				}
			}
			m_LastMousePos = Input.mousePosition;
		}
		
		if(m_AnimateScale && m_DeltaTime < 1f)
		{
			m_DeltaTime += Time.deltaTime;
			if(m_CurrentObject)
			{
				m_CurrentObject.transform.localScale = Vector3.Lerp(m_CurrentObject.transform.localScale, m_StartScale * m_ScaleFactor, m_DeltaTime);
			}
		}
		else
		{
			m_AnimateScale = false;
			m_DeltaTime = 0f;
		}
	}
}