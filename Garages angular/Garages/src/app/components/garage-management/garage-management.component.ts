import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { 
  trigger, 
  state, 
  style, 
  transition, 
  animate 
} from '@angular/animations';

import { Garage } from '../../models/garage.interface';
import { GarageApiService } from '../../services/garage.service';
import { forkJoin, finalize } from 'rxjs';

@Component({
  selector: 'app-garage-management',
  standalone: true,
  imports: [
    CommonModule, 
    FormsModule, 
    MatSelectModule, 
    MatFormFieldModule, 
    MatTableModule, 
    MatButtonModule, 
    MatProgressSpinnerModule,
    MatInputModule, 
    MatCardModule, 
    MatDividerModule
  ],
  templateUrl: './garage-management.component.html',
  styleUrls: ['./garage-management.component.css'],
  // animations: [
  //   trigger('fadeInOut', [
  //     state('void', style({ opacity: 0, transform: 'translateY(20px)' })),
  //     transition('void => *', [
  //       animate('500ms ease-in-out', style({ opacity: 1, transform: 'translateY(0)' }))
  //     ]),
  //   ])
  // ]
})
export class GarageManagementComponent implements OnInit {
  
  // 1b. נתונים ל-Multi Select
  externalGarages: Garage[] = [];
  selectedGaragesCodes: number[] = []; 

  savedGaragesDataSource = new MatTableDataSource<Garage>();
  displayedColumns: string[] = ['misparMosah', 'shemMosah', 'ktovet', 'miktzoa'];

  isLoadingExternal: boolean = false;
  isLoadingSaved: boolean = false;
  isAdding: boolean = false;

  constructor(private garageApi: GarageApiService) {}

  ngOnInit(): void {
    this.fetchExternalGarages();
    this.loadSavedGarages();
  }

  fetchExternalGarages(): void {
    this.isLoadingExternal = true;
    this.garageApi.fetchGaragesFromExternalApi().pipe(
      finalize(() => this.isLoadingExternal = false)
    ).subscribe({
      next: (garages) => {
        this.externalGarages = garages;
      },
      error: (err) => {
        console.error('Error fetching external garages', err);
      }
    });
  }

  loadSavedGarages(): void {
    this.isLoadingSaved = true;
    this.garageApi.getSavedGarages().pipe(
      finalize(() => this.isLoadingSaved = false)
    ).subscribe({
      next: (garages) => {
        this.savedGaragesDataSource.data = garages;
      },
      error: (err) => {
        console.error('Error loading saved garages', err);
      }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.savedGaragesDataSource.filter = filterValue.trim().toLowerCase();
  }

  onAddGarages(): void {
    if (this.selectedGaragesCodes.length === 0) {
      alert('נא לבחור מוסכים להוספה.');
      return;
    }

    const newlySelectedGarages = this.externalGarages.filter(garage => 
      this.selectedGaragesCodes.includes(garage.misparMosah)
    );

    const existingCodes = new Set(this.savedGaragesDataSource.data.map(g => g.misparMosah));
    
    const garagesToAdd = newlySelectedGarages.filter(garage => 
      !existingCodes.has(garage.misparMosah)
    );

    if (garagesToAdd.length === 0) {
      alert('כל המוסכים שבחרת כבר קיימים במערכת.');
      this.selectedGaragesCodes = [];
      return;
    }

    
    const addCalls = garagesToAdd.map(garage => this.garageApi.addGarage(garage));

    this.isAdding = true;
    
    forkJoin(addCalls).pipe(
      finalize(() => this.isAdding = false)
    ).subscribe({
      next: () => {
        alert(`${garagesToAdd.length} מוסכים נוספו בהצלחה!`);
        this.loadSavedGarages(); 
        this.selectedGaragesCodes = []; 
      },
      error: (err) => {
        console.error('Error adding new garages', err);
        alert('אירעה שגיאה במהלך הוספת המוסכים. בדוק את השרת.');
      }
    });
  }
}