: eat-apple!        ( -- ) 1 xdim myrand 1 ydim myrand apple 2! grow! ;
: step! ( xdiff ydiff -- ) head* 2@ move-head! pos+ head* 2! ;

: left?   97 = ;
: up?     119 = ;
: right?  100 = ;
: down?   115 = ;

: choose-direction
   dup left?  if ['] left else
   dup up?    if ['] up else
   dup right? if ['] right else
   dup down?  if ['] down else direction @
   then then then then ;

: perform  direction perform step! ;
: whereto  key? if key choose-direction direction ! drop then ;
: where    whereto perform ;
: apple?    apple? if eat-apple! then ;
: end      cr ." *** GAME OVER ***" cr ;
: step     render dup ms where apple? ;

: gameloop ( time -- ) begin step dead? until drop end ;
