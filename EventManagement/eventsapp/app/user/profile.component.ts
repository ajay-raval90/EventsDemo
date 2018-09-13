import { Component, OnInit, Inject } from '@angular/core'
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { AuthService } from "./auth.service";
import { Router } from '@angular/router';
import { TOASTR_TOKEN, IToastr } from '../common/index';
@Component({
  templateUrl: 'app/user/profile.component.html',
  styles: [
    `em {float:right; color:#E05C65; padding-left:10px}
    .error input {background-color:#E3C3C5}
    .error ::-webkit-input-placeholder {color:#999}
    .error ::-moz-placeholder {color:#999}
    .error :-moz-placeholder {color:#999}
    .error :ms-input-placeholder {color:#999}
    `
  ]
})
export class ProfileComponent implements OnInit {
  profileForm: FormGroup;
  private firstName;
  private lastName;
  constructor( @Inject(TOASTR_TOKEN) private toastr: IToastr, private router: Router, private auth: AuthService) {


  }
  ngOnInit() {
    this.firstName = new FormControl(this.auth.currentUser.firstName, [Validators.required, Validators.pattern('[a-zA-Z].*')]);
    this.lastName = new FormControl(this.auth.currentUser.lastName, Validators.required);
    this.profileForm = new FormGroup({
      firstName: this.firstName,
      lastName: this.lastName
    });
  }
  saveProfile(formValues) {
    this.auth.updateCurrentUser(formValues.firstName, formValues.lastName);
    this.toastr.success("Profile updated successfully");
    //this.router.navigate(['/events']);
  }
  cancel() {
    this.router.navigate(['/events']);
  }

  //VALIDATIONS
  validateFirstName() {
    return (this.firstName.valid || this.firstName.untouched)
  }
  validateLastName() {
    return (this.lastName.valid || this.lastName.untouched)
  }

}