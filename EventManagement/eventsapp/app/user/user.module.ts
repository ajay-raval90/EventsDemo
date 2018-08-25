import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';
import {CommonModule} from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {userRoutes}from './user.routes';
import {ProfileComponent}from './profile.component';
import { LoginComponent } from "./login.component";

@NgModule({
    imports:[
        CommonModule,
        RouterModule.forChild(userRoutes),
        FormsModule,
        ReactiveFormsModule
    ],
    providers:[

    ],
    declarations:[
        ProfileComponent, 
        LoginComponent
    ]
})
export class UserModule{}
