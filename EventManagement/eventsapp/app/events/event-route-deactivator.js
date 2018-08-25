"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var event_service_1 = require("./shared/event-service");
var EventRouteDeactivator = /** @class */ (function () {
    function EventRouteDeactivator(eventService, router) {
        this.eventService = eventService;
        this.router = router;
    }
    EventRouteDeactivator.prototype.canDeactivate = function (component) {
        if (component.isDirty) {
            return confirm("There are unsaved changes? Are you sure want to leave this page?");
        }
        return true;
    };
    EventRouteDeactivator = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [event_service_1.EventService, router_1.Router])
    ], EventRouteDeactivator);
    return EventRouteDeactivator;
}());
exports.EventRouteDeactivator = EventRouteDeactivator;
//# sourceMappingURL=event-route-deactivator.js.map