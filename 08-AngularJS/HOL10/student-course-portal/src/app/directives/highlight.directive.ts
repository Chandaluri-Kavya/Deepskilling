import { Directive, HostBinding, HostListener, Input } from '@angular/core';
@Directive({ selector: '[appHighlight]', standalone: true }) export class HighlightDirective { @Input() appHighlight = 'yellow'; @HostBinding('style.backgroundColor') color = ''; @HostListener('mouseenter') enter() { this.color = this.appHighlight; } @HostListener('mouseleave') leave() { this.color = ''; } }
