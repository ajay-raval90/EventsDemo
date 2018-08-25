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
var UpvoteComponet = /** @class */ (function () {
    function UpvoteComponet() {
        this.vote = new core_1.EventEmitter();
    }
    Object.defineProperty(UpvoteComponet.prototype, "voted", {
        set: function (val) {
            this.iconColor = val ? 'red' : 'white';
        },
        enumerable: true,
        configurable: true
    });
    ;
    UpvoteComponet.prototype.onClick = function () {
        this.vote.emit({});
    };
    __decorate([
        core_1.Output(),
        __metadata("design:type", Object)
    ], UpvoteComponet.prototype, "vote", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Number)
    ], UpvoteComponet.prototype, "count", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Object),
        __metadata("design:paramtypes", [Object])
    ], UpvoteComponet.prototype, "voted", null);
    UpvoteComponet = __decorate([
        core_1.Component({
            selector: 'upvote',
            template: "\n    <div class=\"voteingWidgetContainer pointable\" (click)=\"onClick()\">\n        <div class=\"well votingWidget\">\n            <i [style.color]=\"iconColor\"\n            class=\"glyphicon glyphicon-heart\"></i>\n            \n        <div>\n        <div class=\"badge badge-invers votingCount\">\n            <div>{{count}}</div>\n        </div>\n    </div>\n    ",
            styleUrls: [
                "app/events/upvote.component.css"
            ]
        })
    ], UpvoteComponet);
    return UpvoteComponet;
}());
exports.UpvoteComponet = UpvoteComponet;
//# sourceMappingURL=upvote.component.js.map