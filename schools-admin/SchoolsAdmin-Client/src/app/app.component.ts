import { SuccessModalComponent } from './shared/modals/success-modal/success-modal.component';
import { Component } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SchoolsAdmin-Client';

  constructor(public dialog: MatDialog) { }

}
