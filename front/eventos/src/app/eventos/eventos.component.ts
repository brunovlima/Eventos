import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { error } from 'console';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  // Propriedades
  eventos: any = []

  // Injetores
  constructor(private http: HttpClient) {}

  // Inicialização
  ngOnInit(): void {
    this.getEventos();
  }

  // Métodos
  getEventos(): void {
    this.http.get('https://localhost:7251/evento').subscribe(
      (res: any) => {
        this.eventos = res;
      },
      (error: any) => {
        console.log(Error);
      },
      () => {
        console.log('Subscribe in observable completo')
      }
    );
  }
}
