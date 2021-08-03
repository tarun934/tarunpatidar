export function Assignment(){
    function calc()
        {
            var num1 = Number(document.getElementById('num1').value);
            var num2 = Number(document.getElementById('num2').value);
            var result = 0;
              
              if(document.getElementById('add').checked)
              {
            result = num1 + num2;
              }
              else if(document.getElementById('sub').checked)
              {
            result = num1 - num2;
              }
              else if(document.getElementById('mul').checked)
              {
            result = num1 * num2;
              }
              else
              {
            result = num1 / num2;
              }
              document.getElementById("resultArea").innerHTML +='<h3 class="ans text-light p-3 mt-3 bg-dark"> The Result is :'+result;
              return false;
        }
}