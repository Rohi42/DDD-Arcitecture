import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { WorkItemsService } from '../../services/work-items.service';
import { MatDialog } from '@angular/material/dialog';
import { WorkItems } from '../../models/work-items';
import { ViewEditComponent } from '../view-edit/view-edit.component';
import {MatCardModule} from '@angular/material/card';
import {SelectionModel} from '@angular/cdk/collections';

@Component({
  selector: 'app-bug-list',
  templateUrl: './bug-list.component.html',
  styleUrls: ['./bug-list.component.scss']
})
export class BugListComponent implements OnInit {
  
  constructor(private _http:HttpClient, 
              private _workitemservice:WorkItemsService,
              private _dialog: MatDialog,
             ) {}
  
  displayedColumns: string[] = ['Select','Id', 'SystemTitle', 'CommonPriority', 'DisplayName','TCMReproSteps','CommonSeverity','Action'];
  dataSource:WorkItems[]=[];
  selectAll:boolean=false;
  selected:boolean=false;
  isLoading:boolean=false;

  ngOnInit(): void {
    this.fetchAllWorkItems();
  }


  fetchAllWorkItems()
  {
    this.isLoading=true;
    this._workitemservice.getAllWorkItems().subscribe(
      (val)=>{
        this.dataSource=val;
        this.isLoading=false;
      },
      (err)=>{
        this.isLoading=false;
        alert("Error")
      }
    );
  }


  deleteSelectedRecords()
  {
    this.isLoading=false;
    var selected=this.dataSource.filter(x=>x.select==true).map(s=>s.id);
    this._workitemservice.DeleteSelectedRecoreds(selected).subscribe(
      (val)=>{
        alert("Successfully Deleted");
        this.isLoading=false;
        this.fetchAllWorkItems();
      },
      (err)=>{
        alert("Something Went Wrong");
        this.isLoading=false;
      }
    );
  }

  viewEditform(workitem:any)
  {
    this._dialog.open(ViewEditComponent,{data:workitem});
  }
  addItem()
  {
    this._dialog.open(ViewEditComponent);
  }
  deleteWorkItem(workitem:WorkItems)
  {
    console.log(workitem);
    this._workitemservice.DeleteWorkItems(workitem.id).subscribe(
      (val)=>{
        alert("Work Item Deleted");
        this.fetchAllWorkItems();
      },
      (err)=>{alert("Error")}
    );
  }

  toggleSelectAll()
  {
    if(this.selectAll){
      console.log(this.selectAll);
      this.dataSource.forEach(element => element.select=true);
      this.selectAll=true;
    }
    else
    this.dataSource.forEach(element => element.select=false);
    
  }

  checkboxInfo()
  {
    if(this.dataSource.every(element => element.select==false))
    {
      this.selectAll=false;
    }
  }

  
}


  
  

  
  

