: not      ( b -- b ) true xor ;
: myrand ( a b -- r ) over - utime + swap mod + ;
: y?                  key 121 = ;

( geometry )

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

: place-apple  1 xdim myrand 1 ydim myrand apple 2! ;

( graphics )

: hline ( x y -- ) at-xy ." +" xdim 1 ?do ." -" loop ." +" ;
: vline ( x y -- ) 1+ at-xy ydim 1 ?do ." |" xdim i at-xy ." |" cr loop ;
: draw-frame ( -- ) 0 0 hline 0 0 vline xdim 0 vline 0 ydim hline ;
: draw-snake ( -- ) length @ 0 ?do i segment 2@ at-xy ." #" loop ;
: draw-apple ( -- ) apple 2@ at-xy ." Q" ;
: .score            length @ 3 - . ;

: render page draw-snake draw-apple draw-frame cr .score ;

: center      xdim 2 / ydim 2 / ;
: at-center   center at-xy ;
: .at-center  at-center dup 2 / 0 do 8 emit loop type ;

( logic)

: eat-apple!        ( -- ) place-apple grow! ;
: step! ( xdiff ydiff -- ) head* 2@ move-head! pos+ head* 2! ;

create vi    104 c, 106 c, 107 c, 108 c,
create wasd  97 c, 115 c, 119 c, 100 c,
variable vi?

: keys  vi? @ if vi else wasd then ;

: left?   keys c@ = ;
: down?   keys 1+ c@ = ;
: up?     keys 2 + c@ = ;
: right?  keys 3 + c@ = ;

: either-left   dup left?  if ['] left  rdrop exit then ;
: or-down       dup down?  if ['] down  rdrop exit then ;
: or-up         dup up?    if ['] up    rdrop exit then ;
: or-right      dup right? if ['] right rdrop exit then ;

: choose-direction either-left or-down or-up or-right ( else ) direction @ ;
: whereto  key? if key choose-direction direction ! drop then ;
: move     direction perform step! ;
: where    whereto move ;
: apple?    apple? if eat-apple! then ;
: end      cr ." *** GAME OVER ***" cr ;
: step     render dup ms where apple? ;

: gameloop ( time -- ) begin step dead? until drop end ;

( setup )

: reset-head       0 head ! ;
: reset-length     3 length ! ;
: reset-pos        center snake 2! ;
: reset-snake      reset-head reset-pos reset-length ;
: reset-direction  ['] up direction ! ;

: newgame!  reset-snake place-apple reset-direction ;

: vi?      draw-frame s" Vi keys? (y/n)" .at-center y? vi? ! ;
: greet    draw-frame s" Snake in Forth" .at-center ;
: delay    1000 ms ;
: run      200 gameloop ;
: prompts  greet delay vi? ;
: setup    page newgame! prompts ;
: play?    draw-frame s" Play again? (y/n)" .at-center y? ;
: end     draw-frame cr cr cr bye ;

: go  begin setup run play? not until end ;

go
