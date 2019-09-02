import { Component, OnInit } from '@angular/core';
import { RepositoryService } from '../../shared/services/repository.service';
import { School } from '../../_interfaces/school.model';

@Component({
  selector: 'app-school-list',
  templateUrl: './school-list.component.html',
  styleUrls: ['./school-list.component.css']
})
export class SchoolListComponent implements OnInit {
  public schools: School[];

  constructor(private repository: RepositoryService) { }

  ngOnInit() {
    this.getAllSchools();
  }

  public getAllSchools() {
    const apiAddress = 'api/school';
    this.repository.getData(apiAddress)
    .subscribe(res => {
      this.schools = res as School[];
      console.log(res);
    });
  }

}
