import { Directive, OnInit, Inject, ElementRef, Input } from '@angular/core'
import { JQ_TOKEN } from "./index";

@Directive({
    selector: '[modal-trigger]',
})
export class ModalTriggerDirective implements OnInit {
    private el: HTMLElement;
    private jqueryEl: any;
    @Input('modal-trigger') modalId: string;
    constructor(@Inject(JQ_TOKEN) private $: any, ref: ElementRef) {
        this.el = ref.nativeElement;
        this.jqueryEl = this.$(this.el);
    }
    ngOnInit(): void {
        this.jqueryEl.on("click", () => {
            this.$(`#${this.modalId}`).modal({});
        });
    }

}