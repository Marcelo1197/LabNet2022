import { FormControl, FormGroupDirective, NgForm } from "@angular/forms";
import { ErrorStateMatcher } from "@angular/material/core";

export class CustomErrorMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    return this.someInputIsInvalid(control, form);
  }
  someInputIsInvalid(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    let maxLengthInvalid = control?.dirty && control.errors?.["maxlength"];
    let requiredInvalid = control?.dirty && control.errors?.["required"];
    let patternRegexInvalid = control?.dirty && control.errors?.["pattern"];
    return maxLengthInvalid || (requiredInvalid || patternRegexInvalid);
  }
}
