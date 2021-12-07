: eat-apple!        ( -- ) 1 xdim myrand 1 ydim myrand apple 2! grow! ;
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
: current       direction @ ;

: choose-direction either-left or-down or-up or-right ( else ) current ;
: whereto  key? if key choose-direction direction ! drop then ;
: move     direction perform step! ;
: where    whereto move ;
: apple?    apple? if eat-apple! then ;
: end      cr ." *** GAME OVER ***" cr ;
: step     render dup ms where apple? ;

: gameloop ( time -- ) begin step dead? until drop end ;
