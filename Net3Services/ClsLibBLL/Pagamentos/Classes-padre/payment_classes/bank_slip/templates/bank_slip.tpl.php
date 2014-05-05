<?php
	// This is the HTML template include file (.tpl.php) for the action_edit.php
	// form DRAFT page.  Remember that this is a DRAFT.  It is MEANT to be altered/modified.

	// Be sure to move this out of the generated/ subdirectory before modifying to ensure that subsequent 
	// code re-generations do not overwrite your changes.

?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
    <head>
        <title></title>
        <meta http-equiv="Content-Type" content="text/html charset=ISO-8859-1" />
        <link href="/bankslip/assets/css/bank_slip.css" type="text/css" rel="stylesheet" media="all" />
    </head>
    <body>
        <?php 	$this->RenderBegin() ?>
        <?php   $this->objDefaultWaitIcon->Render();	?>
        <div id="container">
            <!-- Protocolo de Entrega -->
            <div class="drawee top_drawee">
                <ul class="first_line">
                    <li>
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Cedente</label>
                        <p><?=$this->objTransferor->Name ?> - <?=$this->objTransferor->Document ?></p>
                    </li>
                    <li class="top_right">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Agência / Código Cedente</label>
                        <p><?=$this->objBankSlipContract->BranchCode ?></p>
                    </li>
                </ul>
                <ul>
                    <li>
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Sacado</label>
                        <p><?=$this->objBankSlip->Drawee ?> - CNPJ: 10.771.943/0001-71</p>
                    </li>
                    <li class="top_right">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Nosso Número</label>
                        <p><?=$this->objBankSlip->OurNumber ?></p>
                    </li>
                </ul>
                <ul>
                    <li class="medium_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Vencimento</label>
                        <p><strong><?=$this->objBankSlip->Maturity ?></strong></p>
                    </li>
                    <li class="medium_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>No. Documento</label>
                        <p><?=$this->objBankSlip->DocumentNumber ?></p>
                    </li>
                    <li class="small_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Espécie</label>
                        <p><?=$this->objBankSlip->Kind ?></p>
                    </li>
                    <li class="small_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Moeda</label>
                        <p><?=$this->objBankSlipContract->Currency ?></p>
                    </li>
                    <li class="top_right">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label><strong>Valor do Documento</strong></label>
                        <p><strong><?=$this->objBankSlip->Value ?></strong></p>
                    </li>
                </ul>
                <ul>
                    <li class="medium_field receive">
                        <img src="/bankslip/assets/images/separator.png" />
                        <p>Recebí(emos) o bloqueto com essas características.</p>
                    </li>
                    <li class="signature">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Assinatura</label>
                        <p>&nbsp;</p>
                    </li>
                    <li class="bank_use">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Data de Entrega</label>
                        <p>&nbsp;</p>
                    </li>
                    <li class="bank_use">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Nome</label>
                        <p>&nbsp;</p>
                    </li>                    
                </ul>
                <ul class="payment_place">
                    <li>
                        <label>Local do Pagamento</label>
                        <p>Pagável em qualquer banco até o vencimento.</p>
                    </li>
                </ul>                
            </div>
            <hr class="cutline" />
            <!-- Recibo do Sacado -->
            <div class="drawee">
                <ul>
                    <li class="bank_logo"></li>
                    <li class="bank_code"><?=$this->objBankSlipContract->BankCode ?></li>
                    <li class="receipt"><span><?=$this->objBankSlip->TypeableLine ?></span>Recibo do Sacado</li>
                </ul>
                <ul class="right_side no_bottom_line">
                    <li id="company_logo">
                        <img src="/bankslip/assets/images/logos/company/codificar.png" />
                        <label></label>
                        <p></p>                        
                    </li>                
                    <li class="highlight">
                        <label><strong>Vencimento</strong></label>
                        <p><strong><?=$this->objBankSlip->Maturity ?></strong></p>                           
                    </li>
                    <li>
                        <label>Agência / Código Cedente</label>
                        <p><?=$this->objBankSlipContract->BranchCode ?></p>
                    </li>
                    <li>
                        <label>Nosso Número</label>
                        <p><?=$this->objBankSlip->OurNumber ?></p>
                    </li>
                    <li>
                        <label><strong>(=) Valor do Documento</strong></label>
                        <p><strong><?=$this->objBankSlip->Value ?></strong></p>
                    </li>
                    <li>
                        <label>(-) Desconto / Abatimento</label>
                        <p><?=$this->objBankSlip->Discount ?></p>
                    </li>
                    <li>
                        <label>(-) Outras Deduções</label>
                        <p>&nbsp;</p>
                    </li>
                    <li>
                        <label>(+) Mora / Multa</label>
                        <p>&nbsp;</p>
                    </li>
                    <li>
                        <label>(+) Outros Acréscimos</label>
                        <p>&nbsp;</p>
                    </li>
                    <li class="no_bottom_line">
                        <label>(=) Valor cobrado</label>
                        <p>&nbsp;</p>
                    </li>
                </ul>                
                <ul class="left_box">
                    <li>
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Local do Pagamento</label>
                        <p><strong>Pagável em qualquer banco até o vencimento.</strong></p>
                    </li>
                    <li class="bank_use highlight">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Uso do Banco</label>
                        <p>&nbsp;</p>
                    </li>
                </ul>
                <ul class="left_box">
                    <li class="transferor uppercase">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Cedente</label>
                        <p><?=$this->objTransferor->Name ?> - <?=$this->objTransferor->Document ?></p>
                    </li>
                </ul>
                <ul class="left_box">                    
                    <li class="uppercase">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Endereço do Cedente</label>
                        <p><?=$this->objTransferor->Address ?></p>
                    </li>              
                </ul>
                <ul class="left_box">
                    <li class="medium_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Data do Documento</label>
                        <p><?=$this->objBankSlip->DocumentDate ?></p>
                    </li>
                    <li class="medium_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>No. Documento</label>
                        <p><?=$this->objBankSlip->DocumentNumber ?></p>
                    </li>
                    <li class="small_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Espécie doc.</label>
                        <p><?=$this->objBankSlip->Kind ?></p>
                    </li>
                    <li class="small_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Aceite</label>
                        <p><?=$this->objBankSlipContract->Accepted ?></p>
                    </li>
                    <li class="small_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Data Process.</label>
                        <p><?=$this->objBankSlip->ProcessingDate ?></p>
                    </li>                    
                </ul>                
                <ul class="left_box">
                    <li class="medium_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Carteira</label>
                        <p><?=$this->objBankSlipContract->Portfolio ?></p>
                    </li>
                    <li class="small_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Espécie</label>
                        <p><?=$this->objBankSlipContract->Currency?></p>
                    </li>
                    <li class="medium_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Quantidade</label>
                        <p><?=$this->objBankSlipContract->Quantity?></p>
                    </li>
                    <li class="small_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Valor</label>
                        <p>&nbsp;</p>
                    </li>                    
                </ul>
                <ul class="instructions">
                    <li>
                        <label>Instruções de responsabilidade do cedente</label>
                        <br class="clear" />
                        <?=$this->objBankSlip->Instructions ?>
                    </li>
                </ul>
                <ul class="drawee_data">
                    <li>
                        <label>Sacado: </label>
                        <?=$this->objBankSlip->GetDraweeInformation()?>
                        <label>Sacador/Avalista: </label>
                    </li>
                </ul>
                <ul class="form_footer">
                    <li>
                        <label><i>Autenticação Mecânica</i></label>
                        <span class="highlight">
                            Este recibo somente terá validade com a autenticação mecânica ou acompanhado do recibo de pagamento
                            emitido pelo banco. <br />
                            Recebimento através do cheque no. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            do banco <br />
                            Esta quitação só terá validade após o pagamento do cheque acima pelo banco do sacado.
                        </span>
                    </li>
                </ul>
            </div>
            <hr class="cutline" />
            <!-- Ficha de Compensação -->
            <div class="drawee">
                <ul>
                    <li class="bank_logo"></li>
                    <li class="bank_code"><?=$this->objBankSlipContract->BankCode?></li>
                    <li class="type_line"><?=$this->objBankSlip->TypeableLine ?></li>
                </ul>
                <ul>
                    <li>
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Local do Pagamento</label>
                        <p><strong>Pagável em qualquer banco até o vencimento.</strong></p>
                    </li>                
                    <li class="highlight right_box" style="display: block;">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label><strong>Vencimento</strong></label>
                        <p><strong><?=$this->objBankSlip->Maturity ?></strong></p>                           
                    </li>
                </ul>
                <ul>
                    <li class="transferor uppercase">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Cedente</label>
                        <p><?=$this->objTransferor->Name ?></p>
                    </li>
                    <li class="right_box">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Agência / Código Cedente</label>
                        <p><?=$this->objBankSlipContract->BranchCode ?></p>
                    </li>
                </ul>
                <ul>
                    <li class="medium_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Data do Documento</label>
                        <p><?=$this->objBankSlip->DocumentDate ?></p>
                    </li>
                    <li class="medium_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>No. Documento</label>
                        <p><?=$this->objBankSlip->DocumentNumber ?></p>
                    </li>
                    <li class="small_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Espécie doc.</label>
                        <p><?=$this->objBankSlip->Kind ?></p>
                    </li>
                    <li class="small_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Aceite</label>
                        <p><?=$this->objBankSlipContract->Accepted ?></p>
                    </li>
                    <li class="small_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Data Process.</label>
                        <p><?=$this->objBankSlip->ProcessingDate ?></p>
                    </li>
                    <li class="right_box">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Nosso Número</label>
                        <p><?=$this->objBankSlip->OurNumber ?></p>
                    </li>
                </ul>
                <ul>
                    <li class="medium_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Carteira</label>
                        <p><?=$this->objBankSlipContract->Portfolio ?></p>
                    </li>
                    <li class="small_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Espécie</label>
                        <p><?=$this->objBankSlipContract->Currency?></p>
                    </li>
                    <li class="medium_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Quantidade</label>
                        <p><?=$this->objBankSlipContract->Quantity?></p>
                    </li>
                    <li class="small_field">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>Valor</label>
                        <p>&nbsp;</p>
                    </li>                  
                    <li class="right_box">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label><strong>(=) Valor do Documento</strong></label>
                        <p><strong><?=$this->objBankSlip->Value ?></strong></p>
                    </li>
                </ul>
                <ul class="left_box bottom_instructions">
                    <li>
                        <label>Instruções de responsabilidade do cedente</label>
                        <br class="clear" />
                        <?=$this->objBankSlip->Instructions ?>
                    </li>
                </ul>
                <ul class="right_price_data">
                    <li>
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>(-) Desconto / Abatimento</label>
                        <p>&nbsp;</p>                           
                    </li>
                    <li>
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>(-) Outras Deduções</label>
                        <p>&nbsp;</p>
                    </li>
                    <li>
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>(+) Mora / Multa</label>
                        <p>&nbsp;</p>
                    </li>
                    <li>
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>(+) Outros Acréscimos</label>
                        <p>&nbsp;</p>
                    </li>
                    <li class="no_bottom_line">
                        <img src="/bankslip/assets/images/separator.png" />
                        <label>(=) Valor cobrado</label>
                        <p>&nbsp;</p>
                    </li>
                </ul>
                <ul class="drawee_data">
                    <li>
                        <label>Sacado: </label>
                        <?=$this->objBankSlip->GetDraweeInformation()?>
                        <label>Sacador/Avalista: </label>
                    </li>
                </ul>
                <ul class="form_footer">
                    <li class="barcode">
                        <span><?=$this->objBankSlip->BarCode ?></span>
                        <label>Autenticação Mecânica</label>Ficha de Compensação
                    </li>
                </ul>
            </div>
        </div>
        <?php 	$this->RenderEnd() ?>
    </body>
</html>