import { Component, OnInit } from '@angular/core';
import { HotelService } from '../services/hotel.service';
import { Hotel } from '../models/hotel';

@Component({
  selector: 'app-nyhotel',
  templateUrl: './nyhotel.component.html',
  styleUrls: ['./nyhotel.component.css']
})
export class NyhotelComponent implements OnInit {

  public hotels: Hotel[] = [];
  public fileName: string = "New_York_City";
  constructor(private service: HotelService) {

  }

  ngOnInit(): void {
    
    this.service.loadNYHotels(this.fileName)
      .subscribe((res: Hotel[]) => {
        console.info();
        if (res) {
          this.hotels = res;
        }
      });

    setInterval(() => {
      this.refreshHotels();
    }, 60000);
  }

  refreshHotels(): void {
    this.service.loadNYHotels(this.fileName)
      .subscribe((res: Hotel[]) => {
        if (res) {
          this.hotels = res;
        }
      });
  }
}
