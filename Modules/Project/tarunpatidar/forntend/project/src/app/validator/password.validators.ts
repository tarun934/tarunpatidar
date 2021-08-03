import { AbstractControl , ValidationErrors } from "@angular/forms"

export const PasswordValidator = function (control:AbstractControl) : ValidationErrors | null {
    
    let value : string = control.value || '';

    if (!value) 
    {
        return null
    }

    let upperCaseCharacters = /[A-Z]+/g
    if (upperCaseCharacters.test(value) === false)
    {
        return {password : `text has to contine Upper case characters , current value ${value}` };
    }

    let lowerCaseCharacters = /[a-z]+/g
    if (lowerCaseCharacters.test(value) === false)
    {
        return {password : `text has to contine lower case characters , current value ${value}` };
    }

    let numberCaseCharacters = /[0-9]+/g
    if (numberCaseCharacters.test(value) === false)
    {
        return {password : `text has to contine number case characters , current value ${value}` };
    }

    let specialCaseCharacters = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/
    if (specialCaseCharacters.test(value) === false)
    {
        return {password : `text has to contine special case characters , current value ${value}` };
    }
    return null;

}