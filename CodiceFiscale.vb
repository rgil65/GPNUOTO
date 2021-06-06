Public Class CodiceFiscale

#Region "Variabili di classe"
    Private CF As String = ""
    Private Cognome As String = ""
    Private Nome As String = ""
    Private Sesso As String = ""
    Private Giorno As Integer = 0
    Private Mese As Integer = 0
    Private MeseStr As String = ""
    Private Anno2 As Integer = 0
    Private CodiceCatastale As String = ""
    Private CarattereControllo As String = ""
    Private VerificaCF As Boolean = False
    Private ForzaturaCF As Boolean = False
#End Region

    Sub New(ByVal Cognome As String, ByVal Nome As String, ByVal dataNascita As Date, _
                        ByVal codCatastale As String, ByVal Sex As String)
        ' costruttore con parametri inseriti per generazione codice fiscale
        Me.Cognome = Cognome
        Me.Nome = Nome
        If Sex = "M" Or Sex = "F" Then
            Sesso = Sex
        Else
            ' valore non valido
        End If
        If Len(codCatastale) = 4 Then
            CodiceCatastale = UCase(codCatastale)
        Else
            ' valore non valido
        End If
        Giorno = DatePart(DateInterval.Day, dataNascita)
        Mese = DatePart(DateInterval.Month, dataNascita)
        MeseStr = calcolaLetteraMeseNascita(Mese)
        'Anno2 = Right$(CStr(DatePart(DateInterval.Year, dataNascita)), 2)
        Anno2 = Integer.Parse(("" & dataNascita.Year).Substring(2, 2))
        If Cognome <> "" And Nome <> "" And Sesso <> "" And CodiceCatastale <> "" Then
            CF = calcolaCF(Cognome, Nome, dataNascita, Sesso, CodiceCatastale)
            CarattereControllo = Mid$(CF, 16, 1)
        End If
        If CF <> "" Then
            VerificaCF = Check(CF)
        End If
    End Sub

    Sub New(ByVal CodFiscale As String)
        ' costruttore con codice fiscale completo o parziale (senza cod.contr.)
        CF = CodFiscale

        If Len(CodFiscale) >= 15 And Len(CodFiscale) <= 16 Then
            Cognome = Left$(CF, 3)
            Nome = Mid$(CF, 4, 3)
            Anno2 = CInt(Mid$(CF, 7, 2))
            CodiceCatastale = Mid$(CF, 12, 4)
            If Len(CF) = 15 Then
                CarattereControllo = getCarattereControllo(CF)
                CF = CF & CarattereControllo
            ElseIf Len(CF) = 16 Then
                CarattereControllo = Mid$(CF, 16, 1)
            End If
            MeseStr = Mid$(CF, 9, 1)
            Mese = calcolaMeseNasc(MeseStr)
            Sesso = calcolaSexCF(CInt(Mid$(CF, 10, 2)))
            Giorno = calcolaGiornoCF(CInt(Mid$(CF, 10, 2)))
            VerificaCF = Check(CF)
        Else
            ' codice fiscale non valido o incompleto
            VerificaCF = False
        End If
    End Sub

    Sub New()
        ' costruttore senza parametri: il codice fiscale sarà generato
        ' successivamente
    End Sub

    Public Sub registraCF(ByVal CodiceFiscale As String)
        ' memorizza un codice fiscale inserito come parametro nella variabile
        ' interna CF. Utilizzabile per inserire o per modificare il codice
        ' fiscale dopo la creazione dell'oggetto (es. utilizzo del costruttore
        ' senza parametri
        If Len(CodiceFiscale) >= 15 And Len(CodiceFiscale) <= 16 Then
            If Len(CodiceFiscale) = 15 Then
                CarattereControllo = getCarattereControllo(CodiceFiscale)
                CF = CodiceFiscale & CarattereControllo
            Else
                ' lunghezza 16
                CF = CodiceFiscale
                CarattereControllo = Mid$(CodiceFiscale, 16, 1)
            End If
            Cognome = Left$(CodiceFiscale, 3)
            Nome = Mid$(CodiceFiscale, 4, 3)
            Anno2 = CInt(Mid$(CodiceFiscale, 7, 2))
            CodiceCatastale = Mid$(CodiceFiscale, 12, 4)
            MeseStr = Mid$(CodiceFiscale, 9, 1)
            Mese = calcolaMeseNasc(MeseStr)
            Sesso = calcolaSexCF(CInt(Mid$(CodiceFiscale, 10, 2)))
            Giorno = calcolaGiornoCF(CInt(Mid$(CodiceFiscale, 10, 2)))
            VerificaCF = Check(CF)
        Else
            MsgBox("Lunghezza codice fiscale non valida.", MsgBoxStyle.Information)
        End If
    End Sub

    Public Function estraiCF() As String
        ' restituisce il codice fiscale memorizzato
        Return CF
    End Function

    Public Function estraiCognome() As String
        ' restituisce le 3 lettere del cognome dal codice fiscale
        Return Cognome
    End Function

    Public Function estraiNome() As String
        ' restituisce le 3 lettere del nome dal codice fiscale
        Return Nome
    End Function

    Public Function estraiSesso() As String
        ' restituisce "M" o "F"
        Return Sesso
    End Function

    Public Function estraiGiornoNascita() As Integer
        ' restituisce il giorno di nascita memorizzato
        Return Giorno
    End Function

    Public Function estraiMeseNascita() As Integer
        ' restituisce il mese di nascita memorizzato
        Return Mese
    End Function

    Public Function estraiMeseNascitaStr() As String
        ' restituisce il mese di nascita memorizzato come stringa
        Return MeseStr
    End Function

    Public Function estraiAnnoNascita2() As Integer
        ' restituisce l'anno di nascita memorizzato a 2 cifre
        Return Anno2
    End Function

    Public Function estraiCodCatastale() As String
        ' restituisce il codice catastale memorizzato
        Return CodiceCatastale
    End Function

    Public Function estraiCarControllo() As String
        ' restituisce il carattere di controllo memorizzato
        Return CarattereControllo
    End Function

    Public Function estraiVerificaCF() As Boolean
        ' restituisce la verifica del codice fiscale
        Return VerificaCF
    End Function

    Public Function calcolaMeseNasc(ByVal lettera As String) As Integer
        ' calcola il mese rappresentato dalla lettera nel codice fiscale
        Dim mese As Integer = 0
        Select Case lettera
            Case "A" : mese = 1
            Case "B" : mese = 2
            Case "C" : mese = 3
            Case "D" : mese = 4
            Case "E" : mese = 5
            Case "H" : mese = 6
            Case "L" : mese = 7
            Case "M" : mese = 8
            Case "P" : mese = 9
            Case "R" : mese = 10
            Case "S" : mese = 11
            Case "T" : mese = 12
            Case Else
                ' codice mese errato!
        End Select
        Return mese
    End Function

    Public Function calcolaLetteraMeseNascita(ByVal Mese As Integer) As String
        ' restituisce la lettera corrispondente al mese di nascita
        ' in base alla tabella di decodifica del codice fiscale
        Dim meseStr As String = ""
        Dim mesi() As String = {"A", "B", "C", "D", "E", "H", "L", "M", "P", "R", "S", "T"}
        If Mese >= 1 And Mese <= 12 Then
            meseStr = mesi(Mese - 1)
        Else
            ' mese non valido
        End If
        Return meseStr
    End Function

    Public Function calcolaAnnoNasc(ByVal dataNascita As Date) As String
        ' calcola le 2 cifre dell'anno di nascita
        Dim anno As Integer
        anno = dataNascita.Year
        Dim annoStr As String
        annoStr = Right$(Format$(anno, "0000"), 2)
        Return annoStr
    End Function

    Public Function calcolaCognome(ByVal Cognome As String) As String
        ' calcola le 3 lettere del cognome che compongono il codice fiscale
        Dim CognomeEstratto As String = ""
        Dim lunghezza As Integer = Cognome.Length
        Dim i As Integer
        Dim lunghezzaEstratto As Integer = 0
        ' 1^ fase: estrazione consonanti
        CognomeEstratto = Left$(EstraiConsonanti(Cognome), 3)
        lunghezzaEstratto = CognomeEstratto.Length
        If lunghezzaEstratto = 3 Then
            i = lunghezza
        ElseIf lunghezzaEstratto < 3 Then
            ' 2^ fase: estrazione vocali
            CognomeEstratto = Left$(CognomeEstratto & EstraiVocali(Cognome), 3)
            lunghezzaEstratto = Len(CognomeEstratto)
            If lunghezzaEstratto = 3 Then
                i = lunghezza
            End If
        End If
        ' 3^ fase: se consonanti e vocali non bastano, aggiunta di "X"
        If lunghezzaEstratto < 3 Then
            CognomeEstratto = Left$(CognomeEstratto & "XXX", 3)
        End If
        Return CognomeEstratto
    End Function

    Public Function calcolaNome(ByVal Nome As String) As String
        ' calcola le 3 lettere del nome che compongono il codice fiscale
        ' calcola le 3 lettere del cognome che compongono il codice fiscale
        Nome = UCase(Nome)
        Dim NomeEstratto As String = ""
        Dim lunghezza As Integer = Nome.Length
        Dim i As Integer
        Dim lettera As String
        Dim lunghezzaEstratto As Integer = 0
        ' 1^ fase: estrazione consonanti
        For i = 1 To lunghezza
            lettera = Mid$(Nome, i, 1)
            If InStr(1, "AEIOU'-,;:.\/_ ", lettera) > 0 Then
                ' vocale o spazio o punteggiatura(da scartare)
            Else
                ' consonante (da prendere)
                NomeEstratto = NomeEstratto & lettera
                lunghezzaEstratto += 1
            End If
            If lunghezzaEstratto = 4 Then
                NomeEstratto = Mid$(NomeEstratto, 1, 1) & Mid$(NomeEstratto, 3, 2)
                i = lunghezza
            End If
        Next
        ' 2^ fase: se le consonanti non bastano, estrazione vocali
        If lunghezzaEstratto < 3 Then
            For i = 1 To lunghezza
                lettera = Mid$(Nome, i, 1)
                If InStr(1, "AEIOU", lettera) > 0 Then
                    ' vocale (da prendere)
                    NomeEstratto = NomeEstratto & lettera
                    lunghezzaEstratto += 1
                Else
                    ' consonante o altro (da scartare)
                End If
                If lunghezzaEstratto = 3 Then
                    i = lunghezza
                End If
            Next
        End If
        ' 3^ fase: se consonanti e vocali non bastano, aggiunta di "X"
        If lunghezzaEstratto < 3 Then
            NomeEstratto = Left$(NomeEstratto & "XXX", 3)
        End If
        NomeEstratto = UCase(NomeEstratto)
        Return NomeEstratto
    End Function

    Public Function calcolaGiornoNasc(ByVal dataNascita As Date, ByVal sesso As String) As String
        ' calcola le 2 cifre del giorno di nascita + 40 per il sesso femminile
        Dim giornoStr As String
        Dim giornointeger As Integer
        giornointeger = DatePart(DateInterval.Day, dataNascita)
        If sesso = "F" Then
            giornointeger += 40
        ElseIf sesso = "M" Then
            giornointeger += 0
        End If
        giornoStr = Format$(giornointeger, "00")
        Return giornoStr
    End Function

    Public Function calcolaGiornoCF(ByVal giornoCF As Integer) As Integer
        ' estrae il giorno dal giorno di nascita del codice fiscale
        Dim giorno As Integer
        If giornoCF > 40 Then
            giorno = giornoCF - 40
        Else
            giorno = giornoCF
        End If
        Return giorno
    End Function

    Public Function calcolaSexCF(ByVal giornoCF As Integer) As String
        ' estrae il sesso dal giorno di nascita del codice fiscale
        Dim sex As String
        If giornoCF > 40 Then
            sex = "F"
        Else
            sex = "M"
        End If
        Return sex
    End Function

    Public Function Check(ByVal CF As String) As Boolean
        ' controlla se il CF è valido
        ' True = CF valido
        ' False = CF non valido
        If ControllaStringaCF(CF) = False Then
            ' falso: CF errato
            Check = False
            Exit Function
        End If
        Dim CodCheckCF As String = String.Empty
        Dim CodCheckRicalcolato As String
        If Len(CF) = 16 Then
            CodCheckCF = Right$(CF, 1)
        End If
        CodCheckRicalcolato = getCarattereControllo(CF)
        If CodCheckCF = CodCheckRicalcolato Then
            Check = True
        Else
            Check = False
        End If
    End Function

    Public Function getCarattereControllo(ByVal CF As String) As String
        ' input: codice fiscale con o senza carattere di controllo
        ' output: carattere di controllo
        If CF = "" Then
            ' non è stato passato nessun codice fiscale
            getCarattereControllo = ""
            Exit Function
        End If

        If Len(CF) < 15 Or Len(CF) > 16 Then
            ' codice fiscale di lunghezza anomala
            getCarattereControllo = ""
            Exit Function
        End If

        Dim codfis As String
        codfis = Left$(UCase(CF), 15)

        Dim carattere As String
        Dim i As Integer
        Dim somma As Integer
        somma = 0

        For i = 1 To 15
            ' esamino carattere dispari
            carattere = Mid$(codfis, i, 1)
            somma = somma + Lettera2Dispari(carattere)

            ' esamino carattere pari
            i = i + 1
            If i < 16 Then
                ' se arrivo al 16° carattere non faccio nulla
                carattere = Mid$(codfis, i, 1)
                somma = somma + Lettera2Pari(carattere)
            End If
        Next i

        ' trovo il resto della divisione tra somma e 26
        getCarattereControllo = CodCtrl2Lettera(somma Mod 26)

    End Function

    Public Function calcolaCF(ByVal CFparziale As String) As String
        ' input: codice fiscale senza codice controllo (prime 15 cifre)
        ' output: CF completo di codice di controllo
        If (Len(CFparziale) >= 15 And Len(CFparziale) <= 16) Then
            calcolaCF = Left$(CFparziale, 15) & getCarattereControllo(Left$(CFparziale, 15))
        Else
            ' non è un codice fiscale valido (nemmeno parzialmente)
            calcolaCF = String.Empty
        End If
    End Function

    Public Function calcolaCF(ByVal Cognome As String, ByVal nome As String, ByVal dataNascita As Date, ByVal sesso As String, ByVal codiceCatastale As String) As String
        ' input: cognome, nome, data di nascita, sesso e codice catastale
        ' output: codice fiscale completo di codice di controllo
        Dim sCF As String
        Dim sCognome As String
        Dim sNome As String
        Dim sDtNasc As String
        Dim sCFcalcolato As String
        sCF = ""
        sCognome = ""
        sNome = ""
        sDtNasc = ""
        sCFcalcolato = ""
        codiceCatastale = UCase(codiceCatastale)
        If (Cognome <> "" Or nome <> "") And codiceCatastale <> "" Then
            ' cognome
            sCognome = calcolaCognome(Cognome)

            ' nome
            sNome = calcolaNome(nome)

            ' data nascita e sesso
            sDtNasc = EstraiDataNasc(CInt(Format$(dataNascita, "dd")), CInt(Month(dataNascita)), CInt(Year(dataNascita)), sesso)
        End If

        ' unisco i primi 15 caratteri del c.f.
        sCFcalcolato = sCognome & sNome & sDtNasc & codiceCatastale

        ' calcolo il codice fiscale completo di codice di controllo
        sCFcalcolato = sCFcalcolato & getCarattereControllo(sCFcalcolato)

calcolaCF_esci:
        Return sCFcalcolato
    End Function

    Public Function calcolaCF() As String
        Return calcolaCF(Me.Cognome, Me.Nome, estraiDataNascita("19"), Me.Sesso, Me.CodiceCatastale)
    End Function

    Public Function estraiAnnoNascita4(ByVal millennium As String) As Integer
        ' restituisce l'anno di nascita a 4 cifre tenendo conto del
        ' parametro(millennium) e della data di riferimento
        ' millennium = "20" e data 01/07/04 --> 2004
        ' millennium = "19" e data 01/07/99 --> 1999
        ' millennium = "18" e data 01/07/99 --> 1899
        Dim Anno As String
        Anno = Mid$(CF, 7, 2)
        Select Case millennium
            Case "20" : Anno = "20" & Anno
            Case "19" : Anno = "19" & Anno
            Case "18" : Anno = "18" & Anno
            Case Else
                ' millennio errato
        End Select
        estraiAnnoNascita4 = CInt(Anno)
    End Function

    Public Function estraiDataNascita(ByVal millennium As String) As Date
        ' restituisce la data di nascita tenendo conto del parametro millennium
        ' millennium = "20" e data 01/07/04 --> 01/07/2004
        ' millennium = "19" e data 01/07/99 --> 01/07/1999
        ' millennium = "18" e data 01/07/99 --> 01/07/1899
        Dim Anno As String
        Anno = Format$(estraiAnnoNascita4(millennium), "0000")
        Dim Mese As String
        Mese = Format$(calcolaMeseNasc(Mid$(CF, 9, 1)), "00")
        Dim Giorno As String
        Dim tmpGiorno As Integer
        tmpGiorno = CInt(Mid$(CF, 10, 2))
        If tmpGiorno > 40 Then
            tmpGiorno -= 40
        End If
        Giorno = Format$(tmpGiorno, "00")
        estraiDataNascita = CDate(Giorno & "/" & Mese & "/" & Anno)
    End Function

    Public Function EstraiForzaturaCF() As Boolean
        ' restituisce il valore del flag "ForzaturaCF"
        Return ForzaturaCF
    End Function

    Public Function ControllaStringaCF(ByVal CF As String) As Boolean
        ' controlla se la stringa del codice fiscale
        ' è corretta:    XXX XXX 99 X 99 X 999 X
        ' dove:  X=carattere   9=cifra
        ' restituisce:
        '       False = codice fiscale errato
        '       True = codice fiscale formalmente corretto

        Dim sCognome As String
        Dim sNome As String
        Dim sAA As String
        Dim sMM As String
        Dim sGG As String
        Dim sCodCat As String
        Dim sCodCtrl As String
        Dim car As String
        Dim sControllaStringaCF As Boolean
        Dim i As Integer

        ' il codice è giusto (default)
        sControllaStringaCF = True

        If CF = "" Then
            sControllaStringaCF = False
            GoTo ControllaStringaCF_Esci
        End If

        sCognome = Left$(CF, 3)
        sNome = Mid$(CF, 4, 3)
        sAA = Mid$(CF, 7, 2)
        sMM = Mid$(CF, 9, 1)
        sGG = Mid$(CF, 10, 2)
        sCodCat = Mid$(CF, 12, 4)
        sCodCtrl = Mid$(CF, 16, 1)

        For i = 1 To 16
            car = Mid$(CF, i, 1)
            Select Case i
                Case 7, 8, 10, 11, 13, 14, 15
                    ' dev'essere un numero
                    If car >= "0" And car <= "9" Then
                        ' valore corretto
                    Else
                        ' valore errato
                        sControllaStringaCF = False
                        GoTo ControllaStringaCF_Esci
                    End If
                Case 16
                    If car = "" Then
                        ' il codice di controllo non c'è: ok
                    ElseIf car >= "0" And car <= "9" Then
                        ' è un numero: errore!
                        sControllaStringaCF = False
                        GoTo ControllaStringaCF_Esci
                    End If
                Case Else
                    If (car >= "A" And car <= "Z") _
                            Or (car >= "a" And car <= "z") Then
                        ' carattere corretto: ok
                    Else
                        sControllaStringaCF = False
                        GoTo ControllaStringaCF_Esci
                    End If
            End Select
        Next i

ControllaStringaCF_Esci:
        ControllaStringaCF = sControllaStringaCF

    End Function

    Public Function CodCtrl2Lettera(ByVal numero As Integer) As String
        Dim carattere As String = ""
        Dim lettere() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", _
                    "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", _
                    "T", "U", "V", "W", "X", "Y", "Z"}
        If numero >= 0 And numero <= 25 Then
            carattere = lettere(numero)
        Else
            ' non restituire nulla
            MsgBox("Errore in funzione 'CodCtrl2Lettera': " & vbCrLf & _
                   "Numero <" & CStr(numero) & "> non ammesso")
        End If
        CodCtrl2Lettera = carattere
    End Function

    Public Function EstraiConsonanti(ByVal stringa As String) As String

        Dim i As Integer
        Dim car As String
        Dim sEstraiConsonanti As String
        i = 0
        car = ""
        sEstraiConsonanti = ""

        If stringa = "" Then
            sEstraiConsonanti = ""
        Else
            stringa = UCase(stringa)
            For i = 1 To Len(stringa)
                car = Mid$(stringa, i, 1)
                If InStr(1, "BCDFGHJKLMNPQRSTVWXYZ", car) <> 0 Then
                    sEstraiConsonanti = sEstraiConsonanti + car
                End If
            Next i
        End If

        ' restituisci valore
        EstraiConsonanti = sEstraiConsonanti

    End Function

    Public Function EstraiDataNasc(ByVal Giorno As Integer, ByVal Mese As Integer, ByVal Anno As Integer, ByVal sesso As String) As String

        Dim sEstraiDataNasc As String
        sEstraiDataNasc = ""
        Dim sAnno As String
        Dim sMese As String
        Dim sGiorno As String

        If Giorno = 0 Or Mese = 0 Or Anno = 0 Or sesso = "" Then
            ' non calcolare
        Else
            sAnno = Right$(Format$(Anno, "0000"), 2)
            sMese = Me.calcolaLetteraMeseNascita(Mese)
            If UCase(sesso) = "F" Then
                sGiorno = Format$(Giorno + 40, "00")
            Else
                sGiorno = Format$(Giorno, "00")
            End If
            sEstraiDataNasc = sAnno & sMese & sGiorno
        End If

EstraiDataNasc_esci:
        EstraiDataNasc = sEstraiDataNasc

    End Function

    Public Function EstraiVocali(ByVal stringa As String) As String

        Dim i As Integer
        Dim car As String
        Dim sEstraiVocali As String
        i = 0
        car = ""
        sEstraiVocali = ""

        If stringa = "" Then
            sEstraiVocali = ""
        Else
            stringa = UCase(stringa)
            For i = 1 To Len(stringa)
                car = Mid$(stringa, i, 1)
                If InStr(1, "AEIOU", car) > 0 Then
                    sEstraiVocali = sEstraiVocali + car
                End If
            Next i
        End If

        ' restituisci valore
        EstraiVocali = sEstraiVocali

    End Function

    Public Function Lettera2Dispari(ByVal carattere As String) As Integer

        Dim numero As Integer

        Select Case carattere
            Case "0" : numero = 1
            Case "1" : numero = 0
            Case "2" : numero = 5
            Case "3" : numero = 7
            Case "4" : numero = 9
            Case "5" : numero = 13
            Case "6" : numero = 15
            Case "7" : numero = 17
            Case "8" : numero = 19
            Case "9" : numero = 21
            Case "A" : numero = 1
            Case "B" : numero = 0
            Case "C" : numero = 5
            Case "D" : numero = 7
            Case "E" : numero = 9
            Case "F" : numero = 13
            Case "G" : numero = 15
            Case "H" : numero = 17
            Case "I" : numero = 19
            Case "J" : numero = 21
            Case "K" : numero = 2
            Case "L" : numero = 4
            Case "M" : numero = 18
            Case "N" : numero = 20
            Case "O" : numero = 11
            Case "P" : numero = 3
            Case "Q" : numero = 6
            Case "R" : numero = 8
            Case "S" : numero = 12
            Case "T" : numero = 14
            Case "U" : numero = 16
            Case "V" : numero = 10
            Case "W" : numero = 22
            Case "X" : numero = 25
            Case "Y" : numero = 24
            Case "Z" : numero = 23
            Case Else
                ' non restituire nulla
                MsgBox("Errore in funzione 'Lettera2Dispari': " & vbCrLf & _
                       "Carattere <" & carattere & "> (ASCII " & Asc(carattere) & ") non ammesso")
        End Select

        Lettera2Dispari = numero

    End Function

    Public Function Lettera2Pari(ByVal carattere As String) As Integer

        Dim numero As Integer

        Select Case carattere
            Case "0" : numero = 0
            Case "1" : numero = 1
            Case "2" : numero = 2
            Case "3" : numero = 3
            Case "4" : numero = 4
            Case "5" : numero = 5
            Case "6" : numero = 6
            Case "7" : numero = 7
            Case "8" : numero = 8
            Case "9" : numero = 9
            Case "A" : numero = 0
            Case "B" : numero = 1
            Case "C" : numero = 2
            Case "D" : numero = 3
            Case "E" : numero = 4
            Case "F" : numero = 5
            Case "G" : numero = 6
            Case "H" : numero = 7
            Case "I" : numero = 8
            Case "J" : numero = 9
            Case "K" : numero = 10
            Case "L" : numero = 11
            Case "M" : numero = 12
            Case "N" : numero = 13
            Case "O" : numero = 14
            Case "P" : numero = 15
            Case "Q" : numero = 16
            Case "R" : numero = 17
            Case "S" : numero = 18
            Case "T" : numero = 19
            Case "U" : numero = 20
            Case "V" : numero = 21
            Case "W" : numero = 22
            Case "X" : numero = 23
            Case "Y" : numero = 24
            Case "Z" : numero = 25
            Case Else
                ' non restituire nulla
                MsgBox("Errore in funzione 'Lettera2Pari': " & vbCrLf & _
                       "Carattere <" & carattere & "> (ASCII " & Asc(carattere) & ") non ammesso")
        End Select

        Lettera2Pari = numero

    End Function

    Public Function TestCheckCF(ByVal CF As String) As String
        Dim Risultato As Boolean
        Risultato = Check(CF)
        If Risultato = True Then
            TestCheckCF = "OK"
        Else
            TestCheckCF = "KO"
        End If
    End Function

    Public Sub ForzaCF(ByVal Forzatura As Boolean)
        ForzaturaCF = Forzatura
        If ForzaturaCF = True Then
            VerificaCF = True
        Else
            ' codice fiscale non forzato e riverificato
            VerificaCF = Check(Me.CF)
        End If
    End Sub
End Class

