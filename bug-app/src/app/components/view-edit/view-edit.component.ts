import { Component, Inject, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { FormBuilder} from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { WorkItemsService } from '../../services/work-items.service';
import { WorkItems } from '../../models/work-items';
import { BugListComponent } from '../bug-list/bug-list.component';

@Component({
  selector: 'app-view-edit',
  templateUrl: './view-edit.component.html',
  styleUrls: ['./view-edit.component.scss']
})
export class ViewEditComponent implements OnInit{
  @ViewChild(BugListComponent)
  bugListComponent!: BugListComponent;
  isLoading=false;
  stdForm:FormGroup;
  disabled = false;
  workitem:WorkItems={id:0,systemTitle:'',displayName:'',tcmReproSteps:'',commonPriority:'',commonSeverity:'',select:false,rev:0};
  priority: number[] = Array.from({ length: 4 }, (_, index) => index + 1);
  severity:string[]=["2 - High","3 - Medium","4 - Low"];

  constructor(private _fb:FormBuilder, 
              private _workitemservice: WorkItemsService,
              @Inject(MAT_DIALOG_DATA) public data: any,
              private _dialogRef: MatDialogRef<ViewEditComponent>)
            {
              this.stdForm=this._fb.group({
              id: [this.workitem.id,Validators.required],
              systemTitle: [this.workitem.systemTitle,Validators.required],
              displayName: [this.workitem.displayName],
              tcmReproSteps: [this.workitem.tcmReproSteps,Validators.required],
              commonPriority: [this.workitem.commonPriority,Validators.required],
              commonSeverity: [this.workitem.commonSeverity,Validators.required],
              select:[this.workitem.select],
              rev:[this.workitem.rev]
            });
       
            }
            ngOnInit(): void {
               this.stdForm.patchValue(this.data);
              }
             
            onFormSubmit(){
              this.isLoading=true;
              console.log(this.stdForm.value);
              if(this.stdForm.value.id!=0){
                this._workitemservice.UpdateWorkItems(this.stdForm.value).subscribe(
                (val:any)=>{
                  this.isLoading=false;
                  alert("Work Item updated");
                  this._dialogRef.close(true);
                },
                (err:any)=>{
                  alert("Something went wrong");
                  this.isLoading=false;
                  this._dialogRef.close(true);
                }
                );
              }
             else
            {
              if(this.stdForm.valid){
              this._workitemservice.CreateItems(this.stdForm.value).subscribe(
              (val:any)=>{
                alert("Work Item Saved");
                this.isLoading=false;
                this._dialogRef.close(true);
              },
              (err:any)=>{
                alert("Something went wrong");
                this.isLoading=false;
              }
              
              
              );
            }
            else
            {
              alert("fill the required fields");
              this.isLoading=false;
            }

            }
         
          }
       
       
}

