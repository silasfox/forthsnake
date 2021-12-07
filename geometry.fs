200 constant snake-size
50  constant xdim
20  constant ydim

create snake snake-size cells 2 * allot
create apple 2 cells allot
variable head
variable length
variable direction

: segment      ( seg -- adr ) head @ + snake-size mod cells 2 * snake + ;
: pos+ ( x1 y1 x2 y2 -- x y ) rot + -rot + swap ;
: point=                      2@ rot 2@ rot = -rot = and ;

: head*  ( -- x y ) 0 segment ;
: move-head! ( -- ) head @ 1 - snake-size mod head ! ;
: grow!      ( -- ) 1 length +! ;

: left  -1  0 ;
: right  1  0 ;
: down   0  1 ;
: up     0 -1 ;

: wall?     ( -- bool ) head* 2@ 1 ydim within swap 1 xdim within and not ;
: crossing? ( -- bool ) false length @ 1 ?do i segment head* point= or loop ;
: apple?    ( -- bool ) head* apple point= ;
: dead?                 wall? crossing? or ;
