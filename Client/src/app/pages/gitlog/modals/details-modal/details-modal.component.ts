import { Component, Input } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-details-modal-component',
    templateUrl: './details-modal.component.html',
    styleUrls: ['./details-modal.component.css']
})
export class DetailsModalComponent {
    constructor(private modalService: NgbModal) { }

    open() {
        const modalRef = this.modalService.open(DetailsModalComponent);
        modalRef.componentInstance.name = 'World';
    }

}