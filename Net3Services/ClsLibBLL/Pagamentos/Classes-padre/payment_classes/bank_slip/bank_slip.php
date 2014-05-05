<?php
	// Load the Qcodo Development Framework
	require('../includes/prepend.inc.php');
    require('./data_classes/BankSlip_BancoBrasil.class.php');
    require('./data_classes/ContractDataBanking_BancoBrasil.class.php');
    require('./data_classes/Transferor.class.php');

	/**
	 * This is a quick-and-dirty draft QForm object to do Create, Edit, and Delete functionality
	 * of the Action class.  It uses the code-generated
	 * ActionMetaControl class, which has meta-methods to help with
	 * easily creating/defining controls to modify the fields of a Action columns.
	 *
	 * Any display customizations and presentation-tier logic can be implemented
	 * here by overriding existing or implementing new methods, properties and variables.
	 * 
	 *
	 * @package Intranet
	 * @subpackage 
	 */
     
	class BankSlipForm extends QForm {

        protected $objBankSlip;
        protected $objBankSlipData;
        protected $objTransferor;
        protected $objBankSlipContract;

		// Create QForm Event Handlers as Needed

//		protected function Form_Exit() {}
//		protected function Form_Load() {}
//		protected function Form_PreRender() {}
//		protected function Form_Run() {}

		protected function Form_Create() {
          
			// Create default wait icon
			$this->objDefaultWaitIcon = new QWaitIcon($this);
            
            $this->objBankSlipContract = new BankSlipContract_BancoBrasil(QBank::BancoBrasil, "3032", "35165");
            $this->objBankSlipContract->Agreement = "0";
            $this->objBankSlipContract->Contract = "0";
            $this->objBankSlipContract->Portfolio = 18;
                                  
            $this->objTransferor = new Transferor();
            $this->objTransferor->Document = "05.957.264/0001-51";
            $this->objTransferor->Address = "Rua Contria, 1500/804 - A";
            $this->objTransferor->CityState = "Belo Horizonte - MG";
            $this->objTransferor->Name = "Codificar Sistemas Tecnológicos Ltda.";
            
            $this->SetupBankslip();
            
		}
        
		protected function SetupBankslip(){
			$intId = QApplication::PathInfo(0);
			
			$this->objBankSlipData = Bankslip::Load($intId);
			
			if(!$this->objBankSlipData)
				throw new QCallerException('Could not find a Bankslip object with PK arguments: ' . $intId);
                
            $this->objBankSlip = new BankSlip_BancoBrasil($this->objBankSlipContract);
            $this->objBankSlip->Maturity = $this->objBankSlipData->Maturity;
            $this->objBankSlip->Value = $this->objBankSlipData->Value;
            $this->objBankSlip->Kind = "DS";
            $this->objBankSlip->OurNumber = "2262161";
            $this->objBankSlip->DocumentNumber = $this->objBankSlipData->Number;
            $this->objBankSlip->ProcessingDate = $this->objBankSlipData->ProcessingDate;  
            $this->objBankSlip->DocumentDate = $this->objBankSlipData->DocumentDate;
            $this->objBankSlip->Drawee = $this->objBankSlipData->Customer->Name;
            $this->objBankSlip->Address = $this->objBankSlipData->Customer->Address;
            $this->objBankSlip->AddressComplement = $this->objBankSlipData->Customer->Complement;
            $this->objBankSlip->Instruction = $this->objBankSlipData->Instructions;     

		}          


	}

	// Go ahead and run this form object to render the page and its event handlers, implicitly using
	// action_edit.tpl.php as the included HTML template file
	BankSlipForm::Run('BankSlipForm', './templates/bank_slip.tpl.php');
?>