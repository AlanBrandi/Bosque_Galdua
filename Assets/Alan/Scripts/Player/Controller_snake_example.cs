using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_snake_example : MonoBehaviour
{
    //Qualquer c�digo dentro do Update � executado a quantidade m�xima de frames por segundo na qual a m�quina do jogador conseguir executar.
    private void Update()
    {
        /*
        //Caso a dire��o do eixo x for diferente de 0, o jogador consegue mover-se no eixo x, de acordo com o seu controle de prefer�ncia.
        if (this.direction.x != 0f)
        {
            //Caso o valor no input seja menor que -0.95 no eixo y do gamepad, o jogador move-se para cima.
            if (Input.GetAxis("VerticalGamepad") < -0.95)
            {
                this.direction = Vector2.up;
            }
            //Entretanto, caso o valor no input seja maior que .95 no eixo y do gamepad, o jogador move-se para baixo.
            else if (Input.GetAxis("VerticalGamepad") > 0.95)
            {
                this.direction = Vector2.down;
            }
            //Caso o jogador aperte os bot�es W, a seta para cima no teclado ou o bot�o de cima do controle o jogador move-se para cima.
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("AlternativeUp"))
            {
                this.direction = Vector2.up;
            }
            //Entretanto, caso o jogador aperte os bot�es S, a seta para baixo no teclado ou o bot�o de baixo do controle o jogador move-se para baixo.
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetButtonDown("AlternativeDown"))
            {
                this.direction = Vector2.down;
            }
        }
        //Entretanto, caso a dire��o do eixo x n�o for diferente de 0 e a dire��o do eixo y for, o jogador consegue mover-se no eixo y, de acordo com o seu controle de prefer�ncia.
        else if (this.direction.y != 0f)
        {
            //Caso o valor no input seja menor que -0.95 no eixo x do gamepad, o jogador move-se para a esquerda.
            if (Input.GetAxis("HorizontalGamepad") < -0.95)
            {
                this.direction = Vector2.left;
            }
            //Entretanto, caso o valor no input seja maior que .95 no eixo x do gamepad, o jogador move-se para a direita.
            else if (Input.GetAxis("HorizontalGamepad") > 0.95)
            {
                this.direction = Vector2.right;
            }
            //Caso o jogador aperte os bot�es D, a seta direita no teclado ou o bot�o da direita do controle o jogador move-se para a direita.
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetButtonDown("AlternativeRight"))
            {
                this.direction = Vector2.right;
            }
            //Entretanto, caso o jogador aperte os bot�es A, a seta esquerda no teclado ou o bot�o da esquerda do controle o jogador move-se para a esquerda.
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("AlternativeLeft"))
            {
                this.direction = Vector2.left;
            }
        }
        */
    }

}
    
