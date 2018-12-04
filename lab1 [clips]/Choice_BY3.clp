;;****************
;;* DEFFUNCTIONS *
;;****************

(deffunction ask-question (?question $?allowed-values)
   (print ?question)
   (bind ?answer (read))
   (if (lexemep ?answer) 
       then (bind ?answer (lowcase ?answer)))
   (while (not (member$ ?answer ?allowed-values)) do
      (print "1")
      (print ?question)
      (bind ?answer (read))
      (if (lexemep ?answer) 
          then (bind ?answer (lowcase ?answer))))
   ?answer)

(deffunction yes-or-no-p (?question)
   (bind ?response (ask-question ?question yes no y n))
   (if (or (eq ?response yes) (eq ?response y))
       then yes 
       else no))

;;;***************
;;;* QUERY RULES *
;;;***************

;;; * Предметы *  
(defrule mathematics""
 (not (BY3 ?))
   =>
   (assert (matan (yes-or-no-p "Sdaval matematiky? (yes/no)? "))))   

(defrule physics""
 (not (BY3 ?))
   =>
   (assert (physics (yes-or-no-p "Sdaval fisiky? (yes/no)? "))))   

(defrule informatics""
 (not (BY3 ?))
   =>
   (assert (info (yes-or-no-p "Sdaval informatiky? (yes/no)? "))))   
 
 (defrule biology""
 (not (BY3 ?))
   =>
   (assert (biology (yes-or-no-p "Sdaval biologiy? (yes/no)? ")))) 
 
 (defrule chemistry""
 (not (BY3 ?))
   =>
   (assert (chemistry (yes-or-no-p "Sdaval chemistry? (yes/no)? "))))  
 
 (defrule history""
 (not (BY3 ?))
   =>
   (assert (history (yes-or-no-p "Sdaval history? (yes/no)? "))))  
 
 (defrule social""
 (not (BY3 ?))
   =>
   (assert (social (yes-or-no-p "Sdaval obtshestvosnanie? (yes/no)? "))))  
;;; * end Предметы *   

;;; * Категория *  
 (defrule Technical-Category""
 (not (BY3 ?))
   (matan yes)
   (physics yes)
   (info yes)
   =>
   (assert (categ tech)))  

 (defrule Medical-Category""
 (not (BY3 ?))
   (biology yes)
   (chemistry yes)
   =>
   (assert (categ med))) 

 (defrule Humanitarian-Category""
 (not (BY3 ?))
   (history yes)
   (social yes)
   =>
   (assert (categ hum))) 
;;; * end Категория *   

;;; * ОПЫТ *
 (defrule Age""
 (not (BY3 ?))
   =>
   (assert (Age21 (yes-or-no-p "Bolshe 21 Let? (yes/no)? ")))) 
   
 (defrule Work""
 (not (BY3 ?))
   =>
   (assert (work (yes-or-no-p "Rabotal ranee? (yes/no)? ")))) 
   
;;; * end ОПЫТ *

;;; * ОПЫТ *
 (defrule Exp-Hight""
 (not (BY3 ?))
   (work yes)
   (Age21 yes)
   =>
   (assert (exp hight))) 
   
 (defrule Exp-Normal1""
 (not (BY3 ?))
   (work yes)
   (Age21 no)
   =>
   (assert (exp normal))) 
   
 (defrule Exp-Normal2""
 (not (BY3 ?))
   (work no)
   (Age21 yes)
   =>
   (assert (exp normal)))    
   
 (defrule Exp-Low""
 (not (BY3 ?))
   (work no)
   (Age21 no)
   =>
   (assert (exp low))) 
;;; * end ОПЫТ *   
   
 (defrule CityLife""
 (not (BY3 ?))
 (not (MyCity ?))
   =>
   (assert (MyCity (ask-question "Vyberi gorod: Moskva, CPb, Tomsk, EKB, perm, kaliningrad " moskva spb tomsk ekb perm kaliningrad))))
   
;;; * Баллы * 
 (defrule Points""
 (not (BY3 ?))
   =>
   (assert (points (ask-question "Skolko srednii ball EG3? (hight IF >=86/ normal IF >=75 AND <86/ low IF <75)" hight normal low))))
;;; * end Баллы *     
  
 (defrule medalist""
 (not (BY3 ?))
   =>
   (assert (medalist (yes-or-no-p "Ty medalist? (yes/no)? "))))  
  
 (defrule TOP-5""
 (not (BY3 ?))
   (points hight)
   (exp hight)
   (medalist yes)
   =>
   (assert (rating top5)))    
     
(defrule TOP-6-20""
 (not (BY3 ?))
   (points normal)
   (exp normal)
   =>
   (assert (rating top6-20))) 
   
(defrule Pro4ie""
 (not (BY3 ?))
   (points low)
   (exp low)
   =>
   (assert (rating Pro4ie)))   
   
;;;TOP 5      
 (defrule MGY""
   (not (BY3 ?))
   (or (categ hum) (categ tech) (categ med))
   (rating top5)
   (MyCity moskva)
   =>
   (assert (BY3 "MGY"))) 
   
    (defrule Baumana""
   (not (BY3 ?))
   (or (categ hum) (categ tech))
   (rating top5)
   (MyCity moskva)
   =>
   (assert (BY3 "Baumana"))) 
   
    (defrule SPBGY""
   (not (BY3 ?))
   (or (categ hum) (categ tech) (categ med))
   (rating top5)
   (MyCity spb)
   =>
   (assert (BY3 "SPBGY"))) 

;;;TOP 6-20   
    (defrule TGY""
   (not (BY3 ?))
   (or (categ hum) (categ tech))
   (rating top6-20)
   (MyCity tomsk)
   =>
   (assert (BY3 "TGY"))) 
   
    (defrule YrFY""
   (not (BY3 ?))
   (or (categ hum) (categ tech) (categ med))
   (rating top6-20)
   (MyCity ekb)
   =>
   (assert (BY3 "YrFY"))) 
   
    (defrule PYDH""
   (not (BY3 ?))
   (or (categ hum) (categ tech) (categ med))
   (rating top6-20)
   (MyCity moskva)
   =>
   (assert (BY3 "PYDH"))) 

;;;Pro4ie BY3
    (defrule MGIMO""
   (not (BY3 ?))
   (or (categ hum) (categ tech) (categ med))
   (rating Pro4ie)
   (MyCity moskva)
   =>
   (assert (BY3 "MGIMO")))
   
       (defrule PNIPY""
   (not (BY3 ?))
   (or (categ hum) (categ tech))
   (rating Pro4ie)
   (MyCity perm)
   =>
   (assert (BY3 "PNIPY")))
   
       (defrule KGTY""
   (not (BY3 ?))
   (or (categ hum) (categ tech) (categ med))
   (rating Pro4ie)
   (MyCity kaliningrad)
   =>
   (assert (BY3 "KGTY")))
   
       (defrule PGFA""
   (not (BY3 ?))
   (categ med)
   (rating Pro4ie)
   (MyCity perm)
   =>
   (assert (BY3 "PGFA")))

;;;****************
;;;* REPAIR RULES *
;;;****************

(defrule normal-engine-state-conclusions ""
   (runs-normally yes)
   (not (repair ?))
   =>
   (assert (repair "Ремонт не требуется.")))

;;;********************************
;;;* STARTUP AND CONCLUSION RULES *
;;;********************************

(defrule system-banner ""
  (declare (salience 10))
  =>
  (println crlf "Экспертная система выбора ВУЗа" crlf))

(defrule print-repair ""
  (declare (salience 10))
  (BY3 ?item)
  =>
  (println crlf "Предлагаемый ВУЗ:" crlf)
  (println " " ?item crlf))
