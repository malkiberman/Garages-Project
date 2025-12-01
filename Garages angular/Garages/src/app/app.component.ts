import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { GarageManagementComponent } from './components/garage-management/garage-management.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet, 
    GarageManagementComponent 
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'garage-manager';
}