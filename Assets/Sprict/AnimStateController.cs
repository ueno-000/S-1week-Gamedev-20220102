using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStateController : MonoBehaviour
{
    Animator anim;

    void Start() 
    {
        anim = GetComponent<Animator>();
    }

    void Update() 
    {

        if (Input.anyKeyDown) {
            Vector2? action = actionKeyDown();
            if (action.HasValue) {
                // キー入力があればAnimatorにstateをセットする
                setStateToAnimator(vector: action.Value);
                return;
            }
        }
        // 入力からVector2インスタンスを作成
        Vector2 vector = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        // キー入力が続いている場合は、入力から作成したVector2を渡す
        // キー入力がなければ null

        setStateToAnimator(vector: vector != Vector2.zero? vector : (Vector2?)null);

    }

    /**
     * Animatorに状態をセットする
     *    
     */
    private void setStateToAnimator(Vector2? vector) {
        if (!vector.HasValue) 
        {
            anim.speed = 0.0f;
            return;
        }

        Debug.Log(vector.Value);
        anim.speed = 1.0f;
        anim.SetFloat("directionX", vector.Value.x);
        anim.SetFloat("directionY", vector.Value.y);

    }

    /**
     * 特定のキーの入力があればキーにあわせたVector2インスタンスを返す
     * なければnullを返す   
     */
    private Vector2? actionKeyDown() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) return Vector2.up;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) return Vector2.left;
        if (Input.GetKeyDown(KeyCode.DownArrow)) return Vector2.down;
        if (Input.GetKeyDown(KeyCode.RightArrow)) return Vector2.right;
        return null;
    }
}