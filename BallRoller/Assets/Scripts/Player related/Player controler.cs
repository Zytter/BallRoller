using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlls : MonoBehaviour
{
    

        public float speed = 5f;

        void Update()
        {

            // Pobieranie wejœcia u¿ytkownika
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Przemieszczanie gracza
            Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
            transform.Translate(movement * speed * Time.deltaTime);
        }
    
}

