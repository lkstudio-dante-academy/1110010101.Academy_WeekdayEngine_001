using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/** 전역 확장 메서드 */
public static partial class CExtension {
	#region 클래스 함수
	/** 작음 여부를 검사한다 */
	public static bool ExIsLess(this float a_fSender, float a_fRhs) {
		return a_fSender < a_fRhs - float.Epsilon;
	}

	/** 작거나 같음 여부를 검사한다 */
	public static bool ExIsLessEquals(this float a_fSender, float a_fRhs) {
		return a_fSender.ExIsLess(a_fRhs) || a_fSender.ExIsEquals(a_fRhs);
	}

	/** 큰 여부를 검사한다 */
	public static bool ExIsGreate(this float a_fSender, float a_fRhs) {
		return a_fSender > a_fRhs + float.Epsilon;
	}

	/** 크거나 같음 여부를 검사한다 */
	public static bool ExIsGreateEquals(this float a_fSender, float a_fRhs) {
		return a_fSender.ExIsGreate(a_fRhs) || a_fSender.ExIsEquals(a_fRhs);
	}

	/** 같음 여부를 검사한다 */
	public static bool ExIsEquals(this float a_fSender, float a_fRhs) {
		return Mathf.Approximately(a_fSender, a_fRhs);
	}

	/** 월드 => 로컬로 변환한다 */
	public static Vector3 ExToLocal(this Vector3 a_stSender, 
		GameObject a_oParent, bool a_bIsCoord = true) {
		var stVec4 = new Vector4(a_stSender.x, a_stSender.y, a_stSender.z, a_bIsCoord ? 1.0f : 0.0f);
		return a_oParent.transform.worldToLocalMatrix * stVec4;
	}

	/** 로컬 => 월드로 변환한다 */
	public static Vector3 ExToWorld(this Vector3 a_stSender,
		GameObject a_oParent, bool a_bIsCoord = true) {
		var stVec4 = new Vector4(a_stSender.x, a_stSender.y, a_stSender.z, a_bIsCoord ? 1.0f : 0.0f);
		return a_oParent.transform.localToWorldMatrix * stVec4;
	}

	/** 정렬 순서를 변경한다 */
	public static void ExSetSortingOrder(this Renderer a_oSender, string a_oLayer, int a_nOrder) {
		/*
		 * 프로그램이 실행 중에 물체의 정렬 순서 (그리기 순서) 를 변경하고 싶다면 Layer 와 Order 를
		 * 수정하면 된다. (즉, 유니티 컴포넌트 중에 Renderer 상속하는 컴포넌트 모두 그리는 순서를 지니고
		 * 있기 때문에 특정 물체를 항상 다른 물체보다 위에 그려지게 하고 싶다면 해당 속성을 변경하면
		 * 된다는 것을 알 수 있다.)
		 * 
		 * Layer vs Sorting Layer
		 * - Layer 는 컴포넌트가 아닌 Game Object 를 위한 속성이 때문에 정렬 순서 (그리기 순서) 와는
		 * 연관이 없다. 반면, Sorting Layer 실제 화면 상에 물체를 그리는 컴포넌트를 위한 속성이기 때문에
		 * 해당 레이어는 그리기 순서와 연관 되어 있다는 것을 알 수 있다.
		 */
		a_oSender.sortingOrder = a_nOrder;
		a_oSender.sortingLayerName = a_oLayer;
	}

	/** 정렬 순서를 변경한다 */
	public static void ExSetSortingOrder(this TextMeshPro a_oSender, string a_oLayer, int a_nOrder) {
		a_oSender.sortingOrder = a_nOrder;
		a_oSender.sortingLayerID = SortingLayer.NameToID(a_oLayer);
	}
	#endregion // 클래스 함수
}
