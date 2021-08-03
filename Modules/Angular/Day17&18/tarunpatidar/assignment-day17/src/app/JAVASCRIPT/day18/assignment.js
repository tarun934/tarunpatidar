export function Assignment(){
    function change(blank){
        return new Promise((resolve,reject)=>{
          
            if (blank == "")
            {
                let errorMessage={status:"error",message:'<h2 class="text-center text-light">Please enter a string</h2>'};
                reject(errorMessage);
            }
    
    else{
    
        newStr = blank
        .split('')
        .reverse()
        .join('')
        let successMessage={status:"success",message:'<h2 class="text-center text-light">Your reverse string is :  '+ newStr +'</h2>'};
        resolve(successMessage);
    }  
        })
    }
    function normal(){
          let blank = document.getElementById('rev').value;         
             console.log(blank);
             
    
             
    change(blank).then((success)=>{
    document.getElementById('demo').innerHTML = success.message;
    console.log(success);
    },(error)=>{
    document.getElementById('demo').innerHTML = error.message;
    console.log(error);
    
    })
    return false;
           } 
}