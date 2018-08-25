"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var auth_activator_1 = require("./auth.activator");
var profile_component_1 = require("./profile.component");
var login_component_1 = require("./login.component");
exports.userRoutes = [
    { path: 'profile', component: profile_component_1.ProfileComponent, canActivate: [auth_activator_1.AuthActivator] },
    { path: 'login', component: login_component_1.LoginComponent }
];
//# sourceMappingURL=user.routes.js.map