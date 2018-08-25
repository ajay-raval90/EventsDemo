import { Routes } from '@angular/router';
import { AuthActivator } from './auth.activator';
import { ProfileComponent } from './profile.component';
import { LoginComponent } from "./login.component";

export const userRoutes: Routes = [
    { path: 'profile', component: ProfileComponent, canActivate: [AuthActivator] },
    { path: 'login', component: LoginComponent }
]