import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { OnChanges } from '@angular/core';

@Component({
  selector: 'app-star',
  templateUrl: './star.component.html',
  styleUrls: ['./star.component.css']
})
export class StarComponent implements OnChanges{
  
  @Input() starRating: number;
  starWidth: number;

  ngOnChanges(): void {
    this.starWidth = this.starRating * 14;
  }

}
