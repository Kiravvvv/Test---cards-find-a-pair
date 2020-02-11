using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : Game_chracter
{
    [Tooltip("Камера")]
    [SerializeField]
    Transform Camera_obj = null;

    CharacterController CharacterController_ = null;

    protected override void Start()
    {
        if (!CharacterController_ && GetComponent<CharacterController>())
            CharacterController_ = GetComponent<CharacterController>();

        base.Start();
    }

    void Update()
    {
        // Movement();
        Movement_();
        Rotation();
    }

    void Movement_()
    {
        int vector_forward = 0;//Направление движения вперёд
        int vector_right = 0;//Направление движения вправо
        float speed_diagonal = 1;//Скорость движения по диагонали

        if (Input.GetKey(KeyCode.W))
            vector_forward = 1;
        else if (Input.GetKey(KeyCode.S))
            vector_forward = -1;
        else
            vector_forward = 0;

        if (Input.GetKey(KeyCode.D))
            vector_right = 1;
        else if (Input.GetKey(KeyCode.A))
            vector_right = -1;
        else
            vector_right = 0;

        if (vector_forward != 0 && vector_right != 0)
            speed_diagonal = 0.7f;
        else
            speed_diagonal = 1;

        Vector3 direction = My_transform.TransformDirection(Vector3.forward * vector_forward + Vector3.right * vector_right);

        float cur_speed = Speed * speed_diagonal;

        CharacterController_.SimpleMove(direction * cur_speed);

    }

    void Movement()//Передвижение
    {
        int vector_forward = 0;//Направление движения вперёд
        int vector_right = 0;//Направление движения вправо
        float speed_diagonal = 1;//Скорость движения по диагонали

        if (Input.GetKey(KeyCode.W))
            vector_forward = 1;
        else if (Input.GetKey(KeyCode.S))
            vector_forward = -1;
        else
            vector_forward = 0;

        if (Input.GetKey(KeyCode.D))
            vector_right = 1;
        else if (Input.GetKey(KeyCode.A))
            vector_right = -1;
        else
            vector_right = 0;

        if (vector_forward != 0 && vector_right != 0)
            speed_diagonal = 0.7f;
        else
            speed_diagonal = 1;

        Body.velocity = (My_transform.forward * vector_forward + My_transform.right * vector_right) * Speed * speed_diagonal;

    }

    void Rotation()//Поворот камеры
    {
        Camera_obj.Rotate(new Vector3(Input.GetAxis("Mouse Y") * Speed_rotation, 0, 0));
        My_transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Speed_rotation, 0));

    }
}
