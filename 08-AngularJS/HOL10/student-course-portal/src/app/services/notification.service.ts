import { Injectable } from '@angular/core'; @Injectable() export class NotificationService { messages: string[] = []; add(message: string) { this.messages.push(message); } }
