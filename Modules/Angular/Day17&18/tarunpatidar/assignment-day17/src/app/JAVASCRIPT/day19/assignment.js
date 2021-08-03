export function Assignment () {
    let myform = document.forms.circle;
        let myradius = myform.elements.inp;
        
        myform.onsubmit = (event) => {
            event.preventDefault();

            let area = Math.PI * myradius.value * myradius.value;
            console.log(area);
            document.getElementById('output').innerHTML = area.toFixed(2);
        }
}