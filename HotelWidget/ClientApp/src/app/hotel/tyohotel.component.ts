import { Component, OnInit } from '@angular/core';
import { HotelService } from '../services/hotel.service';
import { Hotel } from '../models/hotel';

@Component({
  selector: 'app-tyohotel',
  templateUrl: './tyohotel.component.html',
  styleUrls: ['./tyohotel.component.css']
})
export class TyohotelComponent implements OnInit {

  public hotels: Hotel[] = [];
  public fileName: string = "Tokyo";
  constructor(private service: HotelService) {

  }

  ngOnInit(): void {
    this.service.loadTokyoHotels(this.fileName)
      .subscribe((res: Hotel[]) => {
        if (res) {
          this.hotels = res;
        }
      });

    setInterval(() => {
      this.refreshHotels();
    }, 60000);
  }

  refreshHotels(): void {
    this.service.loadTokyoHotels(this.fileName)
      .subscribe((res: Hotel[]) => {
        if (res) {
          this.hotels = res;
        }
      });
  }

}
