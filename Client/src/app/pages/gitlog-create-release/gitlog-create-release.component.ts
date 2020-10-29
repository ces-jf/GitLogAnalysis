import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FrontParams } from 'src/app/models/frontParams.model';
import { Release } from '../../models/release.model';
import { ReleaseService } from '../../services/release.service';

@Component({
  selector: 'app-gitlog-create-release',
  templateUrl: './gitlog-create-release.component.html',
  styleUrls: ['./gitlog-create-release.component.css']
})
export class GitlogCreateReleaseComponent implements OnInit {

  frontP: FrontParams = new FrontParams();

  submitted = false;

  constructor(
    private releaseService: ReleaseService,
    private router: Router ) { }

  ngOnInit() {
  }

  newRelease(): void {
    this.submitted = false;
    this.frontP = new FrontParams();
  }

  save() {
    this.releaseService.createRelease(this.frontP)
      .subscribe(data => {
        debugger
        console.log(data),
          this.frontP = new FrontParams();
        this.gotoList();
      }, error => console.log(error));

  }
  onSubmit() {
    this.submitted = true;
    this.save();
  }
  gotoList() {
    this.router.navigate(['/releaseList']);
  }
}
