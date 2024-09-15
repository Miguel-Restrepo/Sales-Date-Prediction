import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [MatToolbarModule,],
  templateUrl: './templates/header.component.html',
  styleUrl: './styles/header.component.scss'
})
export class HeaderComponent {

}
