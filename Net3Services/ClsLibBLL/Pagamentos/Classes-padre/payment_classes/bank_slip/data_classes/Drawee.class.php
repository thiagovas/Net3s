<?php

	/**
	 * The abstract Transferor class defined here is
	 * a base class and contains all the basic functionality as well as
	 * basic methods to drawee entity
     * 
     * In portuguese: sacado
	 *  
	 * @package Intranet
     * @property string $Kind the value for strKind
	 * @property string $Document the value for strDocument 
     * @property string $Address the value for strAddress
	 * @property string $CityState the value for strCityState 
     * @property string $Name the value for strName  
	 * @property string $Zipcode the value for strZipCode   
     */
    
    class Drawee extends QBaseClass {
        
    	/**
    	 * Protected member variable that stores document kind 
         * @var string strKind;
    	 */        
        
        protected $strKind;          

    	/**
    	 * Protected member variable that stores document number 
         * @var string strDocument;
    	 */        
        
        protected $strDocument;
        
    	/**
    	 * Protected member variable that stores postal code number 
         * @var string strZipcode;
    	 */        
        
        protected $strZipcode;        
        
    	/**
    	 * Protected member variable that stores address transferor 
         * @var string strAddress;
    	 */        
        
        protected $strAddress;

    	/**
    	 * Protected member variable that stores city/state transferor 
         * @var string strCityState;
    	 */        
        
        protected $strCityState;
        
    	/**
    	 * Protected member variable that stores name transferor 
         * @var string strName;
    	 */        
        
        protected $strName;
        
        public function __get($strName) {
            
            switch ($strName) {
                case 'Document': return $this->strDocument;
                case 'DocumentKind': return (strlen($this->strDocument) > 14) ? "CNPJ" : "CPF";
                case 'Address': return $this->strAddress;
                case 'CityState': return $this->strCityState;
                case 'Name': return $this->strName;
                case 'Zipcode': return $this->strZipcode;
				default:
					try {
            			$objReflection = new ReflectionClass($this);
            			throw new QUndefinedPropertyException("GET", $objReflection->getName(), $strName);
					} catch (QCallerException $objExc) {
						$objExc->IncrementOffset();
						throw $objExc;
					}
            }
        }
        
        public function __set($strName, $mixValue) {
    
            try {
                switch ($strName) {
                    case 'Document': return ($this->strDocument = QType::Cast($mixValue, QType::String));
                    case 'Address': return ($this->strAddress = QType::Cast($mixValue, QType::String));
                    case 'CityState': return ($this->strCityState = QType::Cast($mixValue, QType::String));
                    case 'Name': return ($this->strName = QType::Cast($mixValue, QType::String));
                    case 'Zipcode': return ($this->strZipcode = QType::Cast($mixValue, QType::String));
    				default:
    					try {
                			$objReflection = new ReflectionClass($this);
                			throw new QUndefinedPropertyException("SET", $objReflection->getName(), $strName);
    					} catch (QCallerException $objExc) {
    						$objExc->IncrementOffset();
    						throw $objExc;
    					}                
                    
                }
            } catch (QCallerException $objExc) {
                $objExc->IncrementOffset();
                throw $objExc;
            }
        }        
        
    }

?>