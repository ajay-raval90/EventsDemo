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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var index_1 = require("./index");
var ModalTriggerDirective = /** @class */ (function () {
    function ModalTriggerDirective($, ref) {
        this.$ = $;
        this.el = ref.nativeElement;
        this.jqueryEl = this.$(this.el);
    }
    ModalTriggerDirective.prototype.ngOnInit = function () {
        var _this = this;
        this.jqueryEl.on("click", function () {
            _this.$("#" + _this.modalId).modal({});
        });
    };
    __decorate([
        core_1.Input('modal-trigger'),
        __metadata("design:type", String)
    ], ModalTriggerDirective.prototype, "modalId", void 0);
    ModalTriggerDirective = __decorate([
        core_1.Directive({
            selector: '[modal-trigger]',
        }),
        __param(0, core_1.Inject(index_1.JQ_TOKEN)),
        __metadata("design:paramtypes", [Object, core_1.ElementRef])
    ], ModalTriggerDirective);
    return ModalTriggerDirective;
}());
exports.ModalTriggerDirective = ModalTriggerDirective;
//# sourceMappingURL=modal-trigger.directive.js.map