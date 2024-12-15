import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss'
})
export class EventosComponent implements OnInit {

  // PRorpiedades
  eventos: any = []

  // Ijetores
  constructor() {}

  // Inicialização
  ngOnInit(): void {
    this.getEventos();
  }

  // Métodos
  getEventos(): void{

    this.eventos = [
      {
        Tema: 'Angular',
        Local: 'Belo Horizonte'
      },
      {
        Tema: 'React',
        Local: 'São Paulo'
      },
      {
        Tema: 'Vue',
        Local: 'Rio de Janeiro'
      }
    ]
  }
}

