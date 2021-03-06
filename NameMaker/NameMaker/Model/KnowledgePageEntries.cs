﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NameMaker.Models

{   // This signleton class contains a list with all glossary entries. 
    class KnowledgePageEntries
    {
        private static List<KnowledgeEntry> knowledgeEntryList;

        private KnowledgePageEntries() { }

        public static List<KnowledgeEntry> getEntries()
        {
            if (knowledgeEntryList == null)
            {
                knowledgeEntryList = new List<KnowledgeEntry>();

                // "Was ist ein PICC?" page information
                List<KnowledgeEntryElement> whatIsAPiccEntry = new List<KnowledgeEntryElement>();
                whatIsAPiccEntry.Add(new TextElement("Ihr zentraler PICC Venenkatheter besteht aus weichem, flexiblem Material (Silikon oder Polyurethan). Der lange, schmale Katheter ist mit einem breiteren, verstärkten Ansatz aus Kunststoff, sowie je nach Ausführung mit einer Kunststoffklemme und mit «Flügeln» ausgestattet. Durch diese Flügel kann der Katheter besser auf der Haut ﬁxiert werden. Am äusseren Ende ist eine Schutzkappe angebracht. Diese verhindert, dass Blut zurück in den Katheter fliesst (siehe MicroClave).\n\nManchmal verschreibt der Arzt einen Katheter mit zwei separaten Kanälen (doppellumiger Katheter). Diese zwei Kanäle ermöglichen die Verabreichung unterschiedlicher Substanzen."));
                whatIsAPiccEntry.Add(new ImageElement(new Image { Source = "DoppellumigerPICC.PNG" }, "Doppellumiger PICC: Kunststoffklemme zum Verschliessen des Katheters"));

                List<GlossaryEntry> glossaryWordsForWhatIsAPiccEntry = new List<GlossaryEntry>();
                glossaryWordsForWhatIsAPiccEntry.Add(new GlossaryEntry("Ansatz", "Ein Zwischenstück aus Kunststoff am Katheter. Am Ansatzende des Katheters wird die Schutzkappe (MicroClave) des nadellosen Injektionssystems aufgeschraubt."));
                glossaryWordsForWhatIsAPiccEntry.Add(new GlossaryEntry("Katheter", "Ein weicher Schlauch, der in den Körper eingeführt wird. In diesem Fall handelt es sich um einen peripher eingeführten zentralen Venenkatheter (PICC: Peripherally inserted central venous catheter), der in eine Armvene eingeführt wird. Die Spitze des Katheters beﬁndet sich in einem Bereich mit grosser Blutzirkulation in der Nähe des Herzens. Durch den Katheter können verschiedene Medikamente und Flüssigkeiten verabreicht werden. Dadurch ist es nicht nötig, eine Nadel (Kanüle) direkt in die Vene einzuführen."));
                glossaryWordsForWhatIsAPiccEntry.Add(new GlossaryEntry("PICC (peripher eingeführter zentraler Venenkatheter oder peripherally inserted central venous catheter)", "Ein Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));
                glossaryWordsForWhatIsAPiccEntry.Add(new GlossaryEntry("Schutzkappe des nadellosen Injektionssystems (MicroClave)", "Die Schutzkappe des nadellosen Injektionssystems sorgt dafür, dass kein Blut zurück in den Katheter fliesst. Ausserdem kann die Verabreichung von Flüssigkeiten und Medikamenten in den Blutkreislauf direkt über diese Schutzkappe erfolgen. Sie muss vor jeder Verwendung genauestens desinfiziert werden."));

                KnowledgeEntry whatIsAPicc = new KnowledgeEntry("Was ist ein PICC", whatIsAPiccEntry, glossaryWordsForWhatIsAPiccEntry);
                knowledgeEntryList.Add(whatIsAPicc);

                // "Wozu wird ein PICC verwendet?" page information
                List<KnowledgeEntryElement> whyUseAPiccEntry = new List<KnowledgeEntryElement>();
                whyUseAPiccEntry.Add(new TextElement("Ein PICC ist für die Verabreichung von Flüssigkeiten, von Blutprodukten, Medikamenten und intravenösen Nährlösungen bestimmt. Er kann auch zur Abnahme von Blutproben verwendet werden. Ein PICC kann je nach Therapie mehrere Wochen oder Monate in einer Vene verbleiben.\n\nDer PICC ist insbesondere dann sinnvoll, wenn Ihnen im Rahmen einer Therapie zahlreiche Infusionen verabreicht werden müssen. Dank dem Venenzugang über den PICC müssen die Fachleute nicht für jede Infusion eine neue Einstichstelle schaffen. Der PICC verhindert somit, dass Ihre Venen an Hand und Arm durch diverse Einstiche belastet werden.\n\nDie Verabreichung Ihrer Therapie wird durch den PICC zuverlässiger, komfortabler und einfacher."));
                whyUseAPiccEntry.Add(new ImageElement(new Image { Source = "EinlumigerPICC.PNG" }, "Einlumiger PICC: Weiches, flexibles Kathetermaterial"));

                List<GlossaryEntry> glossaryWordsForWhyUseAPiccEntry = new List<GlossaryEntry>();
                glossaryWordsForWhyUseAPiccEntry.Add(new GlossaryEntry("Intravenöse Therapie (IV-Therapie)", "Ein Medikamenten oder eine Flüssigkeit wird durch eine Vene verabreicht."));
                glossaryWordsForWhyUseAPiccEntry.Add(new GlossaryEntry("Katheter", "Ein weicher Schlauch, der in den Körper eingeführt wird. In diesem Fall handelt es sich um einen peripher eingeführten zentralen Venenkatheter (PICC: Peripherally inserted central venous catheter), der in eine Armvene eingeführt wird. Die Spitze des Katheters beﬁndet sich in einem Bereich mit grosser Blutzirkulation in der Nähe des Herzens. Durch den Katheter können verschiedene Medikamente und Flüssigkeiten verabreicht werden. Dadurch ist es nicht nötig, eine Nadel (Kanüle) direkt in die Vene einzuführen."));
                glossaryWordsForWhyUseAPiccEntry.Add(new GlossaryEntry("PICC (peripher eingeführter zentraler Venenkatheter oder peripherally inserted central venous catheter)", "Ein Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));

                KnowledgeEntry whyUseAPicc = new KnowledgeEntry("Wozu wird ein PICC verwendet?", whyUseAPiccEntry, glossaryWordsForWhyUseAPiccEntry);
                knowledgeEntryList.Add(whyUseAPicc);

                // "Wie wird ein PICC platziert?" page information
                List<KnowledgeEntryElement> howToPlaceAPicc = new List<KnowledgeEntryElement>();
                howToPlaceAPicc.Add(new TextElement("Die Platzierung eines PICC erfolgt durch einen minimal invasiven Eingriff in der Radiologie. Zuerst machen die Fachleute die Haut mit einem Lokalanästhetikum unempﬁndlich. Dann führen sie den PICC in eine Vene in Ihrer Armbeuge oder am Oberarm ein. Die Spitze des Katheters ist in einem Bereich mit hoher Blutzirkulation in der Nähe des Herzens positioniert, um ein möglichst gutes Vermischen Ihrer intravenös verabreichten Medikamente zu ermöglichen. Unmittelbar nach der Platzierung des PICC spülen die Spezialisten den PICC mit Kochsalzlösung oder verdünntem Heparin, um zu verhindern, dass der Katheter verstopft. Anschliessend wird der Katheter mit der MicroClave Schutzkappe verschlossen."));
                howToPlaceAPicc.Add(new ImageElement(new Image { Source = "PiccPlatzierung.PNG" }));
                howToPlaceAPicc.Add(new TextElement("Ob der PICC richtig platziert ist, überprüfen die Fachleute anhand einer Röntgenaufnahme oder mit einem anderen Abbildungsverfahren. Danach ﬁxieren sie den aus dem Körper herausführenden Abschnitt des Katheters mit einer eigens dafür entwickelten Haftplatte (StatLock) auf der Haut. Den Bereich um die Austrittsstelle des Katheters bedecken sie mit einem sterilen Verband. Lässt die Wirkung des Lokalanästhetikums nach dem Einlegen des Katheters nach, können während ein oder zwei Tagen leichte Schmerzen auftreten."));

                List<GlossaryEntry> glossaryWordsForHowToPlageAPiccEntry = new List<GlossaryEntry>();
                glossaryWordsForHowToPlageAPiccEntry.Add(new GlossaryEntry("Austrittsstelle", "Stelle, an welcher der Katheter aus Ihrem Körper herausführt und sichtbar wird - im Fall eines PICC in der Regel am Arm."));
                glossaryWordsForHowToPlageAPiccEntry.Add(new GlossaryEntry("Heparin", "Medikament, das die Bildung eines Blutgerinnsels verhindern kann."));
                glossaryWordsForHowToPlageAPiccEntry.Add(new GlossaryEntry("Intravenöse Therapie (IV-Therapie)", "Ein Medikamenten oder eine Flüssigkeit wird durch eine Vene verabreicht."));
                glossaryWordsForHowToPlageAPiccEntry.Add(new GlossaryEntry("Katheter", "Ein weicher Schlauch, der in den Körper eingeführt wird. In diesem Fall handelt es sich um einen peripher eingeführten zentralen Venenkatheter (PICC: Peripherally inserted central venous catheter), der in eine Armvene eingeführt wird. Die Spitze des Katheters beﬁndet sich in einem Bereich mit grosser Blutzirkulation in der Nähe des Herzens. Durch den Katheter können verschiedene Medikamente und Flüssigkeiten verabreicht werden. Dadurch ist es nicht nötig, eine Nadel (Kanüle) direkt in die Vene einzuführen."));
                glossaryWordsForHowToPlageAPiccEntry.Add(new GlossaryEntry("Kochsalzlösung", "Eine Lösung aus Salz und Wasser."));
                glossaryWordsForHowToPlageAPiccEntry.Add(new GlossaryEntry("PICC (peripher eingeführter zentraler Venenkatheter oder peripherally inserted central venous catheter)", "Ein Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));
                glossaryWordsForHowToPlageAPiccEntry.Add(new GlossaryEntry("Schutzkappe des nadellosen Injektionssystems (MicroClave)", "Die Schutzkappe des nadellosen Injektionssystems sorgt dafür, dass kein Blut zurück in den Katheter fliesst. Ausserdem kann die Verabreichung von Flüssigkeiten und Medikamenten in den Blutkreislauf direkt über diese Schutzkappe erfolgen. Sie muss vor jeder Verwendung genauestens desinfiziert werden."));
                glossaryWordsForHowToPlageAPiccEntry.Add(new GlossaryEntry("Spülung mit Kochsalzlösung", "Zum Spülen des Katheters nach der Verabreichung einer Infusion wird sterile Kochsalzlösung verwendet."));
                glossaryWordsForHowToPlageAPiccEntry.Add(new GlossaryEntry("Verstopfter Katheter", "Ein Katheter mit einem blockierten Hauptkanal. In diesem Fall sind keine Infusionen oder Abnahmen durch den Katheter möglich."));

                KnowledgeEntry howToUseAPicc = new KnowledgeEntry("Wie wird ein PICC platziert?", howToPlaceAPicc, glossaryWordsForHowToPlageAPiccEntry);
                knowledgeEntryList.Add(howToUseAPicc);
            }
            return knowledgeEntryList;
        }
    }
}
